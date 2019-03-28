using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TP_EveTools.Infrastructure.Commands;
using TP_EveTools.Infrastructure.Commands.DScan;
using TP_EveTools.Infrastructure.Services;
using System.Threading.Tasks;
using TP_EveTools.Infrastructure.Fetchers;
using TP_EveTools.Core.Domain;
using System.Linq;

namespace TP_EveTools.Infrastructure.Handlers.DScan
{
    public class AddDScanHandler : ICommandHandler<AddDScan>
    {
        private readonly IDScanService _dScanService;

        public AddDScanHandler(IDScanService dScanService)
        {
            _dScanService = dScanService;
        }

        private static HashSet<string> _structures = new HashSet<string>{
            "Station", "Sun", "Astrahus", "Raitaru", "Azbel",
            "Fortizar", "Keepstar", "Sotiyo", "Tatara", "Athanor",
            "Planet", "Moon", "Asteroid Belt", "Customs Office"
        };

        private static string YieldSystemNameFromPOCO(string str)
        {
            var s = str.Split(new string[] { " (" }, StringSplitOptions.None);
            return s[1].Substring(0, s[1].Length - 2);
        }
        private static string YieldSystemName(string str)
        {
            return str.Split(new string[] { " - " }, StringSplitOptions.None)[0];
        }
        private static string CheckForSystemName(HashSet<string[]> strs)
        {
            string sysName = "Unknown";
            foreach (var str in strs)
            {
                foreach (var type in _structures)
                {
                    if (str[2].Contains(type))
                    {
                        if (type == "Customs Office")
                        {
                            sysName = YieldSystemNameFromPOCO(
                                Regex.Replace(str[1], @"\bM{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})\b", "")
                            );
                            return sysName;
                        }
                        else
                        {
                            sysName = YieldSystemName(
                            Regex.Replace(str[1], @"\bM{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})\b", ""));
                            return sysName;
                        }
                    }
                }
            }
            return sysName;
        }
        public async Task HandleAsync(AddDScan command)
        {
            var strs = Regex.Replace(command.content, @"<[^>]+>|", "")
                .Trim()
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string sysName = "";

            var entries = new HashSet<string[]>();

            foreach (var c in strs)
            {
                entries.Add(c.Split('\t'));
            }
            sysName = CheckForSystemName(entries);

            var shipList = new List<Ship>();
            var uniqueShips = new HashSet<Ship>();
            var uniqueTypes = new HashSet<string>();
            var uniqueClasses = new HashSet<string>();
            var interestingTargets = new List<Ship>();

            foreach (var entry in entries)
            {
                var ship = ShipFetcher.ReturnShip(entry[2]);
                if (ship.Type != "Unknown")
                {
                    shipList.Add(ship);
                    uniqueShips.Add(ship);
                    uniqueClasses.Add(ship.Class);
                    uniqueTypes.Add(ship.Type);
                }
                if (ship.Class == "Unique")
                {
                    interestingTargets.Add(ship);
                }
            }

            var shipCount = new HashSet<ShipCount>();
            var typeCount = new HashSet<TypeCount>();
            var classCount = new HashSet<ClassCount>();

            foreach (var us in uniqueShips)
            {
                shipCount.Add(
                    new ShipCount
                    {
                        Name = us.Name,
                        Count = 0
                    }
                );
            }
            foreach (var ut in uniqueTypes)
            {
                typeCount.Add(
                    new TypeCount
                    {
                        Name = ut,
                        Count = 0
                    }
                );
            }
            foreach (var uc in uniqueClasses)
            {
                classCount.Add(
                    new ClassCount
                    {
                        Name = uc,
                        Count = 0
                    }
                );
            }

            foreach (var ship in shipList)
            {
                var sc = shipCount.FirstOrDefault(x => x.Name == ship.Name);
                var tc = typeCount.FirstOrDefault(x => x.Name == ship.Type);
                var cc = classCount.FirstOrDefault(x => x.Name == ship.Class);

                shipCount.Remove(sc);
                sc.Count += 1;
                shipCount.Add(sc);

                typeCount.Remove(tc);
                tc.Count += 1;
                typeCount.Add(tc);

                classCount.Remove(cc);
                cc.Count += 1;
                classCount.Add(cc);
            }

            var sortedSC = new HashSet<ShipCount>();
            var sortedTC = new HashSet<TypeCount>();
            var sortedCC = new HashSet<ClassCount>();
            foreach (var x in shipCount.OrderByDescending(x => x.Count))
            {
                if (x.Count != 0)
                    sortedSC.Add(x);
            }
            foreach (var x in typeCount.OrderByDescending(x => x.Count))
            {
                if (x.Count != 0)
                    sortedTC.Add(x);
            }
            foreach (var x in classCount.OrderByDescending(x => x.Count))
            {
                if (x.Count != 0)
                    sortedCC.Add(x);
            }

            var dscan = new TP_EveTools.Core.Domain.DScan
            {
                id = command.id,
                SystemName = sysName,
                Ships = sortedSC,
                Types = sortedTC,
                Classes = sortedCC,
                InterestingTargets = interestingTargets
            };

            await _dScanService.AddAsync(dscan);
        }
    }
}
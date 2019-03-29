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

        private static HashSet<ItemCount> SortSet(HashSet<ItemCount> set)
        {
            var SortedSet = new HashSet<ItemCount>();
            foreach (var x in set.OrderByDescending(x => x.Count))
            {
                if (x.Count != 0)
                    SortedSet.Add(x);
            }
            return SortedSet;
        }

        private static string[] FormatRawHtmlTextString(string str)
            => Regex.Replace(str, @"<[^>]+>|", "")
                .Trim()
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        private static HashSet<string[]> SeparateDScanColumnsByTabs(string[] DScanLines)
        {
            var Set = new HashSet<string[]>();
            foreach (var Line in DScanLines)
            {
                Set.Add(Line.Split('\t'));
            }

            return Set;
        }

        private static HashSet<ItemCount> PrepareSetForCounting(HashSet<string> uniqueSet)
        {
            var CountSet = new HashSet<ItemCount>();

            foreach (var us in uniqueSet)
            {
                CountSet.Add(
                    new ItemCount
                    {
                        Name = us,
                        Count = 0
                    }
                );
            }
            return CountSet;
        }

        public async Task HandleAsync(AddDScan command)
        {
            var shipList = new List<Ship>();
            var uniqueShips = new HashSet<string>();
            var uniqueTypes = new HashSet<string>();
            var uniqueClasses = new HashSet<string>();
            var interestingTargets = new HashSet<Ship>();
            string sysName = "";

            var DScanLines = FormatRawHtmlTextString(command.content);

            var entries = SeparateDScanColumnsByTabs(DScanLines);

            sysName = CheckForSystemName(entries);

            foreach (var entry in entries)
            {
                var ship = ShipFetcher.ReturnShip(entry[2]);
                if (ship.Type != "Unknown")
                {
                    shipList.Add(ship);
                    uniqueShips.Add(ship.Name);
                    uniqueClasses.Add(ship.Class);
                    uniqueTypes.Add(ship.Type);
                }
                if (interestingTargets.FirstOrDefault(x => x.Name == ship.Name) == null)
                {
                    if (ship.Class == "Unique" || ship.Type == "Combat Scanner Probe")
                    {
                        interestingTargets.Add(ship);
                    }
                }
            }

            var shipCount = PrepareSetForCounting(uniqueShips);
            var typeCount = PrepareSetForCounting(uniqueTypes);
            var classCount = PrepareSetForCounting(uniqueClasses);

            foreach (var ship in shipList)
            {
                var sc = shipCount.FirstOrDefault(x => x.Name == ship.Name);
                var tc = typeCount.FirstOrDefault(x => x.Name == ship.Type);
                var cc = classCount.FirstOrDefault(x => x.Name == ship.Class);

                sc.Count += 1;
                tc.Count += 1;
                cc.Count += 1;
            }

            var sortedSC = SortSet(shipCount);
            var sortedTC = SortSet(typeCount);
            var sortedCC = SortSet(classCount);

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
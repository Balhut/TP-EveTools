using System.Collections.Generic;

namespace TP_EveTools.Core.Domain
{
    public class DScan
    {
        public string id { get; set; }
        public string SystemName { get; set; }
        public HashSet<ShipCount> Ships { get; set; }
        public HashSet<TypeCount> Types { get; set; }
        public HashSet<ClassCount> Classes { get; set; }
        public HashSet<Ship> InterestingTargets { get; set; }

        public DScan(){
            SystemName = "Unknown";
        }
    }
}
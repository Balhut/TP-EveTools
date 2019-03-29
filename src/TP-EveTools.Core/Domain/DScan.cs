using System;
using System.Collections.Generic;

namespace TP_EveTools.Core.Domain
{
    public class DScan
    {
        public string id { get; set; }
        public string SystemName { get; set; }
        public HashSet<ItemCount> Ships { get; set; }
        public HashSet<ItemCount> Types { get; set; }
        public HashSet<ItemCount> Classes { get; set; }
        public HashSet<Ship> InterestingTargets { get; set; }
        public DateTime createdAt { get; set; }

        public DScan(){
            createdAt = DateTime.UtcNow;
        }
    }
}
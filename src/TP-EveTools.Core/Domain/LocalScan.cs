using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_EveTools.Core.Domain
{
    public class LocalScan
    {
        public string id { get; set; }
        public HashSet<BasicCharacter> CharacterList { get; set; }
        public HashSet<CorporationCount> CorporationList { get; set; }
        public HashSet<AllianceCount> AllianceList { get; set; }
        public DateTime createdAt { get; set; }

        protected LocalScan() { }

        public LocalScan(string Id, HashSet<BasicCharacter> characterList, HashSet<CorporationCount> corporationList,
            HashSet<AllianceCount> allianceList)
        {
            id = Id;
            CharacterList = characterList;
            CorporationList = corporationList;
            AllianceList = allianceList;
            createdAt = DateTime.UtcNow;
        }
    }
}
using System;
using System.Collections.Generic;

namespace TP_EveTools.Core.Domain
{
    public class LocalScan
    {
        public string id { get; }
        public HashSet<BasicCharacter> CharacterList { get; }
        public HashSet<CorporationCount> CorporationList { get; }
        public HashSet<AllianceCount> AllianceList { get; }
        public DateTime createdAt { get; }
        public DateTime refreshedAt { get; }
        public DateTime expiriesAt { get; }

        protected LocalScan() { }

        public LocalScan(string Id, HashSet<BasicCharacter> characterList, HashSet<CorporationCount> corporationList,
            HashSet<AllianceCount> allianceList)
        {
            id = Id;
            CharacterList = characterList;
            CorporationList = corporationList;
            AllianceList = allianceList;
            createdAt = DateTime.Now;
            refreshedAt = DateTime.Now;
            expiriesAt = refreshedAt.AddDays(2);
        }
    }
}
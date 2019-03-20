using System.Collections.Generic;

namespace TP_EveTools.Core.Domain
{
    public class LocalScan
    {
        public HashSet<BasicCharacter> CharacterList { get; set; }
        public HashSet<CorporationCount> CorporationList { get; set; }
        public HashSet<AllianceCount> AllianceList { get; set; }
    }
}
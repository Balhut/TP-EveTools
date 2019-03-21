using System;

namespace TP_EveTools.Core.Domain
{
    public class Alliance
    {
        public int alliance_id { get; set; }
        public int creator_corporation_id { get; set; }
        public int creator_id { get; set; }
        public DateTime date_founded { get; set; }
        public string name { get; set; }
        public string ticker { get; set; }
    }
}
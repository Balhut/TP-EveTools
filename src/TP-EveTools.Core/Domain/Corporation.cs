using System;

namespace TP_EveTools.Core.Domain
{
    public class Corporation
    {
        public int alliance_id { get; set; }
        public int ceo_id { get; set; }
        public int creator_id { get; set; }
        public DateTime date_founded { get; set; }
        public string description { get; set; }
        public int home_station_id { get; set; }
        public int member_count { get; set; }
        public string corporation_name { get; set; }
        public int shares { get; set; }
        public int tax_rate { get; set; }
        public string ticker { get; set; }
        public string url { get; set; }
        public bool war_eligible { get; set; }
    }
}
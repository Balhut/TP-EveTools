using System;

namespace TP_EveTools.Infrastructure.DTO
{
    public class AllianceDTO
    {
        public int creator_corporation_id { get; set; }
        public int faction_id {get; set;}
        public int creator_id { get; set; }
        public DateTime date_founded { get; set; }
        public int executor_corporation_id { get; set; }
        public string name { get; set; }
        public string ticker { get; set; }
    }
}
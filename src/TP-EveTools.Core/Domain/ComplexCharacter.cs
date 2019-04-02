using System;

namespace TP_EveTools.Core.Domain
{
    public class ComplexCharacter
    {
        public int alliance_id { get; set; }
        public int ancestry_id { get; set; }
        public DateTime birthday { get; set; }
        public int bloodline_id { get; set; }
        public int corporation_id { get; set; }
        public string description { get; set; }
        public int faction_id { get; set; }
        public string gender { get; set; }
        public string name { get; set; }
        public int race_id { get; set; }
        public float security_status { get; set; }

        public ComplexCharacter() {
            alliance_id = 0;
         }

        public ComplexCharacter(int Alliance_id, int Ancestry_id, DateTime Birthday,
            int Bloodline_id, int Corporation_id, string Description, int Faction_id,
                string Gender, string Name, int Race_id, float Security_status)
        {
            alliance_id = Alliance_id;
            ancestry_id = Ancestry_id;
            birthday = Birthday;
            bloodline_id = Bloodline_id;
            corporation_id = Corporation_id;
            description = Description;
            faction_id = Faction_id;
            gender = Gender;
            name = Name;
            race_id = Race_id;
            security_status = Security_status;
        }




    }
}
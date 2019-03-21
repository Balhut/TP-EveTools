namespace TP_EveTools.Core.Domain
{
    public class FormattedCharacter
    {
        BasicCharacter Character { get; }
        public string CorporationName { get; }
        public string AllianceName { get; }

        protected FormattedCharacter(){}

        public FormattedCharacter(BasicCharacter character, string corporationName, string allianceName){
            Character = character;
            CorporationName = corporationName;
            AllianceName = AllianceName;
        }
    }
}
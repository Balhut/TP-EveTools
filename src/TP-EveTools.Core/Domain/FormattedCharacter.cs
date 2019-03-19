namespace TP_EveTools.Core.Domain
{
    public class FormattedCharacter
    {
        ComplexCharacter Character { get; }
        public string CorporationName { get; }
        public string AllianceName { get; }

        protected FormattedCharacter(){}

        public FormattedCharacter(ComplexCharacter character, string corporationName, string allianceName){
            Character = character;
            CorporationName = corporationName;
            AllianceName = AllianceName;
        }
    }
}
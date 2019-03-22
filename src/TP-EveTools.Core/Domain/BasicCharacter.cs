namespace TP_EveTools.Core.Domain
{
    public class BasicCharacter
    {
        public int id { get; set; }
        public string name { get; set; }

        public BasicCharacter(){}

        public BasicCharacter(int Id, string Name){
            id = Id;
            name = Name;
        }

    }
}
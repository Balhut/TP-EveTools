namespace TP_EveTools.Core.Domain
{
    public class BasicCharacter
    {
        public int id { get; }
        public string name { get; }

        public BasicCharacter(){}

        public BasicCharacter(int Id, string Name){
            id = Id;
            name = Name;
        }

    }
}
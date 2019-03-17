namespace TP_EveTools.Core.Domain
{
    public class BasicCharacter
    {
        public string Id { get; }
        public string Name { get; }

        protected BasicCharacter(){}

        public BasicCharacter(string id, string name){
            Id = id;
            Name = name;
        }

    }
}
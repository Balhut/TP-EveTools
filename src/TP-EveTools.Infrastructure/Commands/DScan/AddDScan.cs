namespace TP_EveTools.Infrastructure.Commands.DScan
{
    public class AddDScan : ICommand
    {
        public string id { get; set; }
        public string content { get; set; }
    }
}
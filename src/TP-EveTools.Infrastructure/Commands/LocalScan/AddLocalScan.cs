namespace TP_EveTools.Infrastructure.Commands.LocalScan
{
    public class AddLocalScan : ICommand
    {
        public string id { get; set; }
        public string content { get; set; }

    }
}
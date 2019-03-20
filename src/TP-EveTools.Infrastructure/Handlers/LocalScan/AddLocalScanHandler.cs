using System;
using System.Threading.Tasks;
using TP_EveTools.Infrastructure.Commands;
using TP_EveTools.Infrastructure.Commands.LocalScan;

namespace TP_EveTools.Infrastructure.Handlers.LocalScan
{
    public class AddLocalScanHandler : ICommandHandler<AddLocalScan>
    {
        public async Task HandleAsync(AddLocalScan command)
        {
            Console.WriteLine(command.id + "\n" + command.content);
        }
    }
}
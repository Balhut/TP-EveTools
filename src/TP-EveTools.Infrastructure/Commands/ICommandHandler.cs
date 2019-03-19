using System.Threading.Tasks;

namespace TP_EveTools.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}
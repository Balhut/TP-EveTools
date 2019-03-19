using System;
using System.Threading.Tasks;
using Autofac;

namespace TP_EveTools.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        public CommandDispatcher(IComponentContext context){
            _context = context;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command == null){
                throw new ArgumentNullException(nameof(command), $"Command '{typeof(T).Name}' cannot be empty.");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
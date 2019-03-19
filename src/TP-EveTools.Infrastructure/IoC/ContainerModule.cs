using Autofac;
using Microsoft.Extensions.Configuration;
using TP_EveTools.Infrastructure.IoC.Modules;

namespace TP_EveTools.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<MongoModule>();
            builder.RegisterModule<ServiceModule>();

            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}
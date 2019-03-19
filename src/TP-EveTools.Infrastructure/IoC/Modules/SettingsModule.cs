using Autofac;
using Microsoft.Extensions.Configuration;
using TP_EveTools.Infrastructure.Extensions;
using TP_EveTools.Infrastructure.Mongo;

namespace TP_EveTools.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration){
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder){
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                    .SingleInstance();
        }
    }
}
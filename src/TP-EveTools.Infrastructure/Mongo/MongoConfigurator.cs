using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace TP_EveTools.Infrastructure.Mongo
{
    public static class MongoConfigurator
    {
        private static bool _initialized;

        public static void Initialize(){
            if(_initialized){
                return;
            }
            _initialized = true;
        }

        private static void RegisterConventions(){
            ConventionRegistry.Register("EveToolsConventions", new MongoConvention(), x => true);
        }

        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>{
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String)
            };
        }
    }
}
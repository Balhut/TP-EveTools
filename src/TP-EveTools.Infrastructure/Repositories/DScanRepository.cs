using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TP_EveTools.Core.Domain;
using TP_EveTools.Core.Repositories;

namespace TP_EveTools.Infrastructure.Repositories
{
    public class DScanRepository : IDScanRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public DScanRepository(IMongoDatabase database)
        {
            _database = database;
        }
        private IMongoCollection<DScan> DScans => _database.GetCollection<DScan>("DScans");
        public async Task AddAsync(DScan ls)
        {
            await DScans.InsertOneAsync(ls);
        }

        public async Task<DScan> GetAsync(string id)
            => await DScans.AsQueryable().FirstOrDefaultAsync(x => x.id == id);
    }
}
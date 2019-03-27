using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TP_EveTools.Core.Domain;
using TP_EveTools.Core.Repositories;

namespace TP_EveTools.Infrastructure.Repositories
{
    public class LocalScanRepository : ILocalScanRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;

        public LocalScanRepository(IMongoDatabase database)
        {
            _database = database;
        }
        private IMongoCollection<LocalScan> LocalScans => _database.GetCollection<LocalScan>("LocalScans");
        public async Task AddAsync(LocalScan ls)
        {
            await LocalScans.InsertOneAsync(ls);
        }

        public async Task<LocalScan> GetAsync(string id)
            => await LocalScans.AsQueryable().FirstOrDefaultAsync(x => x.id == id);
    }
}
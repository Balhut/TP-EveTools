using System.Threading.Tasks;
using TP_EveTools.Core.Domain;
using TP_EveTools.Core.Repositories;

namespace TP_EveTools.Infrastructure.Services
{
    public class LocalScanService : ILocalScanService
    {
        private readonly ILocalScanRepository _localScanRepository;

        public LocalScanService(ILocalScanRepository localScanRepository){
            _localScanRepository = localScanRepository;
        }
        public async Task AddAsync(LocalScan ls)
        {
            await _localScanRepository.AddAsync(ls);
        }

        public async Task<LocalScan> GetAsync(string Id)
        {
            return await _localScanRepository.GetAsync(Id);
        }

        public async Task RefreshAsync(LocalScan ls)
        {
            await _localScanRepository.RefreshAsync(ls);
        }
    }
}
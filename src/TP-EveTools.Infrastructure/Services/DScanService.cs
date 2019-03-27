using System.Threading.Tasks;
using TP_EveTools.Core.Domain;
using TP_EveTools.Core.Repositories;

namespace TP_EveTools.Infrastructure.Services
{
    public class DScanService : IDScanService
    {
        private readonly IDScanRepository _dScanRepository;

        public DScanService(IDScanRepository dScanRepository)
        {
            _dScanRepository = dScanRepository;
        }
        public async Task AddAsync(DScan ds)
        {
            await _dScanRepository.AddAsync(ds);
        }

        public async Task<DScan> GetAsync(string Id)
            => await _dScanRepository.GetAsync(Id);
    }
}
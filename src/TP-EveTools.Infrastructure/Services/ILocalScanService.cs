using System.Threading.Tasks;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Infrastructure.Services
{
    public interface ILocalScanService : IService
    {
         Task<LocalScan> GetAsync(string Id);
         Task AddAsync(LocalScan ls);
         Task RefreshAsync(LocalScan ls);
    }
}
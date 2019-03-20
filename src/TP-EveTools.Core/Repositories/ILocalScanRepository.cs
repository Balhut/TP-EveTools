using System.Threading.Tasks;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Core.Repositories
{
    public interface ILocalScanRepository : IRepository
    {
        Task<LocalScan> GetAsync(string id);
        Task AddAsync(LocalScan ls);
        Task RefreshAsync(LocalScan ls);
    }
}
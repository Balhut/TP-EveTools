using System.Threading.Tasks;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Infrastructure.Services
{
    public interface IDScanService : IService
    {
         Task<DScan> GetAsync(string Id);
         Task<DScan> AddAsync(DScan ds);
         Task<DScan> RefreshAsync(DScan ds);
    }
}
using System.Threading.Tasks;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Infrastructure.Services
{
    public interface IDScanService : IService
    {
         Task<DScan> GetAsync(string Id);
         Task AddAsync(DScan ds);
    }
}
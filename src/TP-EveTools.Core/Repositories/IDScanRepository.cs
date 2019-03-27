using System.Threading.Tasks;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Core.Repositories
{
    public interface IDScanRepository : IRepository
    {
        Task<DScan> GetAsync(string id);
        Task AddAsync(DScan ds);
    }
}
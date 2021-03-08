using System.Threading;
using System.Threading.Tasks;
using TAL.AppCore.Entities;

namespace TAL.AppCore.Interfaces
{
    public interface IOccupationRepository : IBaseRepository<Occupation>
    {
        Task<Occupation> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

using System.Threading;
using System.Threading.Tasks;
using TAL.AppCore.Entities;

namespace TAL.AppCore.Interfaces
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<Member> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

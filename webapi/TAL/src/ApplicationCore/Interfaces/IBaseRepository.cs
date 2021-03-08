using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TAL.AppCore.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
    }
}

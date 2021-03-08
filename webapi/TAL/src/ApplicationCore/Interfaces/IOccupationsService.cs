using System.Collections.Generic;
using System.Threading.Tasks;
using TAL.AppCore.Entities;

namespace TAL.AppCore.Interfaces
{
    public interface IOccupationsService
    {
        Task<IEnumerable<Occupation>> GetOccupations();
        Task<Occupation> GetOccupation(int id);
    }
}

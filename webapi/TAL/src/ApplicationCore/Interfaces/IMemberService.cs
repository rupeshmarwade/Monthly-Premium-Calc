using System.Collections.Generic;
using System.Threading.Tasks;
using TAL.AppCore.Entities;

namespace TAL.AppCore.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMember(int id);
    }
}

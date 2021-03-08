using System.Threading.Tasks;
using TAL.AppCore.Entities;

namespace TAL.AppCore.Interfaces
{
    public interface IPremiumService
    {
        Task<decimal?> CalculateMonthlyPremium(Member member);
    }
}

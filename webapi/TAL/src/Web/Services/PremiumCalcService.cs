
using System.Threading.Tasks;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;
using TAL.WebApi.Dtos;

namespace TAL.WebApi.Services
{
    public interface IPremiumCalcService
    {
        Task<decimal?> CalculateMonthlyPremium(MemberDto member);
    }

    public class PremiumCalcService : IPremiumCalcService
    {
        private readonly IPremiumService _premiumService;

        public PremiumCalcService(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }

        public async Task<decimal?> CalculateMonthlyPremium(MemberDto dto)
        {
            var member = new Member
            {
                MemberId = dto.MemberId,
                OccupationId = dto.OccupationId,
                Age = dto.Age,
                Dob = dto.Dob.GetValueOrDefault(),
                Name = dto.Name,
                DeathSumInsured = dto.DeathSumInsured
            };
            var response=await _premiumService.CalculateMonthlyPremium(member);
            return response ?? null;
        }
    }
}

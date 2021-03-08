using System;
using System.Threading.Tasks;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;

namespace TAL.AppCore.Services
{
    public class PremiumService: IPremiumService
    {
        private readonly IOccupationsService _occupationsService;

        public PremiumService(IOccupationsService occupationsService)
        {
            _occupationsService = occupationsService;
        }

        public async Task<decimal?> CalculateMonthlyPremium(Member member)
        {
            var occupation = await _occupationsService.GetOccupation(member.OccupationId);

           var monthlyPremium = (member.DeathSumInsured * (decimal)member.Age * (decimal)occupation.OccupationRating.Factor)/(1000 * 12);

            return Math.Round(monthlyPremium, 2);
        }
    }
}

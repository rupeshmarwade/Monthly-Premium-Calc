using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;
using TAL.WebApi.Dtos;
using TAL.WebApi.Services;

namespace TAL.WebApi.Controllers
{
    public class PremiumController : BaseApiController
    {
        private readonly IPremiumCalcService _premiumCalcService;
        public PremiumController(IPremiumCalcService premiumCalcService)
        {
            _premiumCalcService = premiumCalcService;
        }
    
       
        [HttpPost("premium/monthly")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Occupation>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Occupation>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Occupation>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMonthlyPremium([Required] MemberDto member)
        {
            var premium = await _premiumCalcService.CalculateMonthlyPremium(member);

            return Ok(premium);
        }
    }
}
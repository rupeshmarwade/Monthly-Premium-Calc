using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;

namespace TAL.WebApi.Controllers
{
    public class OccupationController : BaseApiController
    {
        private readonly IOccupationsService _occupationsService;
        public OccupationController(IOccupationsService occupationsService)
        {
            _occupationsService = occupationsService;
        }
    
        [HttpGet("occupations")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Occupation>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Occupation>), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Occupation>> GetOccupations()
        {
            return await _occupationsService.GetOccupations();
        }
    }
}
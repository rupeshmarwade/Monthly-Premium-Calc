using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAL.AppCore.Entities;
using TAL.AppCore.Interfaces;

namespace TAL.WebApi.Controllers
{
    public class MembersController : BaseApiController
    {
        private readonly IMemberService _memberService;
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
    
        [HttpGet("members")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Member>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Member>), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _memberService.GetMembers();
        }
    }
}
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TAL.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BaseApiController : ControllerBase
    {
        
    }
}
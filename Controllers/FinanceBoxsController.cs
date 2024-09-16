using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nheejods.Dtos.Commons;

namespace nheejods.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FinanceBoxsController : ControllerBase
    {
        [HttpGet("health-check")]
        public IActionResult GetHealthCheck()
        {
            return StatusCode(200, new BaseResponseDto<object>()
            {
                IsSuccess = true,
                Message = "Successful",
                Data = null
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace KaryeramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Test() => Ok("ver");
    }
}

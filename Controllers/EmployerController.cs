using KaryeramAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KaryeramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployerProfile(int id)
        {
            var profile = await _employerService.GetEmployerProfileByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }
    }
}

using KaryeramAPI.DTOs;
using KaryeramAPI.Helpers;
using KaryeramAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace KaryeramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public readonly IEmployerService _employerService;
        private readonly ILogger<AuthController> _logger;

        public EmployerController(IEmployerService employerService, ILogger<AuthController> logger)
        {
            _employerService = employerService;
            _logger=logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployerProfile(EmployerProfileDTO dto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId)) return Unauthorized();

            var profile = await _employerService.AddProfile(userId, dto);
            if(profile == null) return NotFound();
            var profileDTO = new EmployerProfileDTO
            {
                CompanyName = profile.CompanyName,
                Industry = profile.Industry,
                ContactEmail = profile.ContactEmail,
                CompanyWebsite = profile.CompanyWebsite,
                ContactPhone = profile.ContactPhone,
                LogoUrl = profile.LogoUrl
            };
            return Ok(profileDTO);
        }

        [Authorize(Roles = "Employer")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetEmployerProfile()
        {
            _logger.LogWarning("qisqirim usduve ay mezahir");
            var userId = User.GetUserId();
            var profile = await _employerService.GetEmployerProfileByUserIdAsync(userId);
            if (profile == null) { return NotFound("cigirim usduve"); }
            var profileDTO = new EmployerProfileDTO
            {
                CompanyName = profile.CompanyName,
                Industry = profile.Industry,
                ContactEmail = profile.ContactEmail,
                CompanyWebsite = profile.CompanyWebsite,
                ContactPhone = profile.ContactPhone,
                LogoUrl = profile.LogoUrl
            };
            return Ok(profileDTO);
        }
    }
}

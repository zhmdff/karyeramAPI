using KaryeramAPI.DTOs;
using KaryeramAPI.Helpers;
using KaryeramAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KaryeramAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        public readonly IJobSeekerService _jobSeekerService;

        public JobSeekerController(IJobSeekerService jobSeekerService)
        {
            _jobSeekerService = jobSeekerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobSeekerProfile(JobSeekerProfileDTO dto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId)) return Unauthorized();

            var profile = await _jobSeekerService.AddProfile(userId, dto);
            if (profile == null) return NotFound();
            var profileDTO = new JobSeekerProfileDTO
            {
                FullName = profile.FullName,
                ContactEmail = profile.ContactEmail,
                ContactPhone = profile.ContactPhone,
                DateOfBirth = profile.DateOfBirth,
                ProfilePictureUrl = profile.ProfilePictureUrl
            };
            return Ok(profileDTO);
        }

        [Authorize(Roles = "JobSeeker")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetJobSeekerProfile()
        {
            var userId = User.GetUserId();
            var profile = await _jobSeekerService.GetJobSeekerProfileByUserIdAsync(userId);
            if (profile == null) { return NotFound(); }
            var profileDTO = new JobSeekerProfileDTO
            {
                FullName = profile.FullName,
                ContactEmail = profile.ContactEmail,
                ContactPhone = profile.ContactPhone,
                DateOfBirth = profile.DateOfBirth,
                ProfilePictureUrl = profile.ProfilePictureUrl
            };
            return Ok(profileDTO);
        }
    }
}

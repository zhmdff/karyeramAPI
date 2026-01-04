using KaryeramAPI.DTOs;
using KaryeramAPI.Helpers;
using KaryeramAPI.Models;
using KaryeramAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KaryeramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IJobService _jobService;

        public JobController(IJobService jobService) {
            _jobService = jobService; 
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public async Task<JobResponseDTO?> CreateJobAsync(CreateJobRequest dto)
        {
            var userId = User.GetUserId();
            JobResponseDTO job = await _jobService.CreateJobAsync(userId, dto);
            return job;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobsAsync()
        {
            var jobs = await _jobService.GetJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("all")]
        public async Task<List<Job>?> GetAllJobsAsync()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return jobs;
        }
    }
}

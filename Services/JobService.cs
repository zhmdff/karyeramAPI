using KaryeramAPI.DTOs;
using KaryeramAPI.Models;
using KaryeramAPI.Repositories;

namespace KaryeramAPI.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IEmployerRepository _employerRepository;

        public JobService(IJobRepository jobRepository, IEmployerRepository employerRepository)
        {
            _jobRepository = jobRepository;
            _employerRepository = employerRepository;
        }


        public async Task<JobResponseDTO?> CreateJobAsync(int userId, CreateJobRequest dto)
        {
            var employerProfile = await _employerRepository.GetProfileByUserIdAsync(userId);
            if (employerProfile == null) return null;

            Job job = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                Requirements = dto.Requirements,
                EmployerProfileId = employerProfile.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(30)
            };

            var jobDB = await _jobRepository.CreateJobAsync(job);

            JobResponseDTO jobDTO = new JobResponseDTO
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                EmployerProfileId = job.EmployerProfileId,
                EmployerName = employerProfile.CompanyName,
                LocationId = job.LocationId,
                LocationText = job.LocationText,
                Salary = job.Salary,
                MinAge = job.MinAge,
                MaxAge = job.MaxAge,
                JobType = job.JobType,
                ExperienceLevel = job.ExperienceLevel,
                EducationLevel = job.EducationLevel,
                Skills = job.Skills,
                IsPremium = job.IsPremium,
                PostedAt = job.PostedAt,
                ExpiresAt = job.ExpiresAt,
                IsActive = job.IsActive,
                ViewCount = job.ViewCount,
                ApplicationCount = job.ApplicationCount,
                CategoryId = job.CategoryId,
                CategoryName = job.Category?.Name,
                SubCategoryId = job.SubCategoryId,
                SubCategoryName = job.SubCategory?.Name
            };

            return jobDTO;
        }


        public async Task<List<Job>?> GetJobsAsync()
        {
            return await _jobRepository.GetJobsAsync();
        }

        public async Task<List<Job>?> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllJobsAsync();
        }
    }
}

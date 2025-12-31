using KaryeramAPI.DTOs;
using KaryeramAPI.Models;
using KaryeramAPI.Repositories;

namespace KaryeramAPI.Services
{
    public class JobSeekerService : IJobSeekerService
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;

        public JobSeekerService(IJobSeekerRepository jobSeekerRepository)
        {
            _jobSeekerRepository = jobSeekerRepository;
        }

        public async Task<JobSeekerProfile?> GetJobSeekerProfileByIdAsync(int id) => await _jobSeekerRepository.GetProfileByIdAsync(id);

        public async Task<JobSeekerProfile?> GetJobSeekerProfileByUserIdAsync(int userId) => await _jobSeekerRepository.GetProfileByUserIdAsync(userId);

        public async Task<JobSeekerProfile> AddProfile(int userId, JobSeekerProfileDTO dto)
        {
            var checkProfile = await _jobSeekerRepository.GetProfileByUserIdAsync(userId);
            if (checkProfile != null) return null!;

            var jobSeekerProfile = new JobSeekerProfile
            {
                UserId = userId,
                FullName = dto.FullName,
                ContactEmail = dto.ContactEmail,
                ContactPhone = dto.ContactPhone,
                DateOfBirth = dto.DateOfBirth,
                ProfilePictureUrl = dto.ProfilePictureUrl
            };

            var result = await _jobSeekerRepository.AddAsync(jobSeekerProfile);

            return result;
        }
    }
}

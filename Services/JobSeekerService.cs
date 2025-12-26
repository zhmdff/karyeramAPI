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

        public async Task<JobSeekerProfile> GetJobSeekerProfileByIdAsync(int id)
        {
            var jobSeekerProfile = await _jobSeekerRepository.GetProfileByIdAsync(id);

            if (jobSeekerProfile == null)
            {
                throw new KeyNotFoundException("Employer profile not found.");
            }

            return jobSeekerProfile;
        }

    }
}

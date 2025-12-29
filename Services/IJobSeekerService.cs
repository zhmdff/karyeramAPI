using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IJobSeekerService
    {
        Task<JobSeekerProfile> GetJobSeekerProfileByIdAsync(int jobSeekerId);
        Task<JobSeekerProfile> GetJobSeekerProfileByUserIdAsync(int userId);
    }
}

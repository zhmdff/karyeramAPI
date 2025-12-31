using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface IJobSeekerRepository
    {
        Task<JobSeekerProfile?> GetProfileByIdAsync(int id);
        Task<JobSeekerProfile?> GetProfileByUserIdAsync(int userId);
        Task<JobSeekerProfile> AddAsync(JobSeekerProfile jobSeekerProfile);
    }
}

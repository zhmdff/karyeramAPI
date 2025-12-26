using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface IJobSeekerRepository
    {
        Task<JobSeekerProfile?> GetProfileByIdAsync(int id);
        Task AddAsync(JobSeekerProfile jobSeekerProfile);
    }
}

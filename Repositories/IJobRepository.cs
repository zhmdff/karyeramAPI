using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface IJobRepository
    {
        Task<Job?> CreateJobAsync(Job job);
        Task<List<Job>?> GetJobsAsync();
        Task<List<Job>?> GetAllJobsAsync();
    }
}

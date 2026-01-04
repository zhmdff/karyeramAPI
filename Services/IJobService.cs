using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IJobService
    {
        Task<List<Job>?> GetJobsAsync();
        Task<List<Job>?> GetAllJobsAsync();
        Task<JobResponseDTO?> CreateJobAsync(int userId, CreateJobRequest dto);
    }
}

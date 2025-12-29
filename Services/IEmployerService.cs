using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IEmployerService
    {
        Task<EmployerProfile> GetEmployerProfileByUserIdAsync(int userId);
        Task<EmployerProfile> GetEmployerProfileByIdAsync(int employerId);
    }
}

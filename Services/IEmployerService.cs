using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IEmployerService
    {
        Task<EmployerProfile> GetEmployerProfileByIdAsync(int employerId);
    }
}

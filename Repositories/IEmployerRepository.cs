using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface IEmployerRepository
    {
        Task<EmployerProfile?> GetProfileByIdAsync(int id);
        Task<EmployerProfile?> GetProfileByUserIdAsync(int userId);
        Task AddAsync(EmployerProfile employerProfile);
    }
}

using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface IEmployerRepository
    {
        Task<EmployerProfile?> GetProfileByIdAsync(int id);
        Task AddAsync(EmployerProfile employerProfile);
    }
}

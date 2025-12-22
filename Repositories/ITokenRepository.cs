using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface ITokenRepository
    {
        Task AddAsync(RefreshToken token);
        Task<RefreshToken?> GetAsync(int userId, string rawToken);
        Task DeleteAsync(int userId, string rawToken);
    }
}
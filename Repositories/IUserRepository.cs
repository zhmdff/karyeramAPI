using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistsByEmailAsync(string email);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<User?> GetByRefreshTokenAsync(string refreshToken);
        Task UpdateRefreshTokenAsync(int userId, string newRefreshToken);
    }


}

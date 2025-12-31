using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Repositories
{
    public interface ITokenRepository
    {
        Task AddAsync(RefreshToken token);
        Task<RefreshToken?> GetRefreshTokenAsync(string tokenHash);
        Task<RefreshToken?> GetRefreshTokenByIdAsync(int userId, string rawToken);
        Task RevokeAsync(int tokenId);
        Task DeleteAsync(int userId, string rawToken);
    }
}
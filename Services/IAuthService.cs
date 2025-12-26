using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<AuthResponse> RefreshTokenAsync(int id, string refreshToken);
    }
}

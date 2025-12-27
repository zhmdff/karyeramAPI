using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request, HttpContext httpContext);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken);
        Task<User?> GetUserByRefreshTokenAsync(string rawToken);
    }
}

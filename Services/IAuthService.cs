using KaryeramAPI.DTOs;
using KaryeramAPI.Models;

namespace KaryeramAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request, HttpContext httpContext);
        Task<AuthResponse> RefreshTokenAsync(string rawToken, HttpContext httpContext);
        Task<User?> GetUserByRefreshTokenAsync(string rawToken);
        Task<User?> GetUserByIdAsync(int id);
    }
}

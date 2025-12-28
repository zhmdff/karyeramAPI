using KaryeramAPI.DTOs;
using KaryeramAPI.Helpers;
using KaryeramAPI.Models;
using KaryeramAPI.Repositories;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KaryeramAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config, ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _config = config;
        }


        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            if (await _userRepository.ExistsByEmailAsync(request.Email)) throw new Exception("User already exists");

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _userRepository.AddAsync(user);

            return new AuthResponse();
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request, HttpContext httpContext)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) throw new Exception("User not found");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) throw new Exception("Invalid password");

            var refreshToken = JwtHelper.GenerateRefreshToken();
            var refreshTokenHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));
            await _tokenRepository.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshTokenHash,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(90),
                IsRevoked = false,
            });

            httpContext.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(90),
                Path = "/",
                Domain = "localhost"
            });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var accessToken = JwtHelper.GenerateJwtToken(user, _config, claims);
            return new AuthResponse
            {
                User = new UserDto(user.Email, user.UserRole.ToString()),
                AccessToken = accessToken,
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(string rawToken, HttpContext httpContext)
        {
            var storedToken = await _tokenRepository.GetRefreshTokenAsync(rawToken) ?? throw new Exception("Invalid or expired refresh token");
            await _tokenRepository.RevokeAsync(storedToken.Id);

            var newRefreshToken = JwtHelper.GenerateRefreshToken();
            await _tokenRepository.AddAsync(new RefreshToken
            {
                UserId = storedToken.UserId,
                TokenHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(newRefreshToken))),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(90),
                IsRevoked = false,
            });

            httpContext.Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(90),
                Path = "/",
                Domain = "localhost"
            });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, storedToken.User.Id.ToString()),
                new Claim(ClaimTypes.Email, storedToken.User.Email),
                new Claim(ClaimTypes.Role, storedToken.User.UserRole.ToString())
            };

            var newAccessToken = JwtHelper.GenerateJwtToken(storedToken.User, _config, claims);
            return new AuthResponse {
                User = new UserDto(storedToken.User.Email, storedToken.User.UserRole.ToString()),
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken 
            };
        }

        public async Task<User?> GetUserByRefreshTokenAsync(string rawToken)
        {
            var tokenEntity = await _tokenRepository.GetRefreshTokenAsync(rawToken);
            if (tokenEntity == null) return null;
            return tokenEntity.User;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return user;
        }

    }

}

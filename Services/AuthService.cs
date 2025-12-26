using KaryeramAPI.DTOs;
using KaryeramAPI.Helpers;
using KaryeramAPI.Models;
using KaryeramAPI.Repositories;
using System.Security.Claims;

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
            if (await _userRepository.ExistsByEmailAsync(request.Email))
                throw new Exception("User already exists");

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _userRepository.AddAsync(user);

            return new AuthResponse();
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) throw new Exception("Invalid credentials");

            var refreshToken = JwtHelper.GenerateRefreshToken();
            var refreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);

            await _tokenRepository.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = refreshTokenHash,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(90)
            });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var accessToken = JwtHelper.GenerateJwtToken(user, _config, claims);

            return new AuthResponse { AccessToken = accessToken };
        }

        public async Task<AuthResponse> RefreshTokenAsync(int id, string refreshToken)
        {
            var storedToken = await _tokenRepository.GetAsync(id, refreshToken);
            if (storedToken == null) throw new Exception("Invalid or expired refresh token");

            await _tokenRepository.DeleteAsync(storedToken.UserId, refreshToken);

            var user = await _userRepository.GetByIdAsync(storedToken.UserId) ?? throw new KeyNotFoundException("User not found");
            var newRefreshToken = JwtHelper.GenerateRefreshToken();

            await _tokenRepository.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                TokenHash = BCrypt.Net.BCrypt.HashPassword(newRefreshToken),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(90)
            });

            var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserRole.ToString())
                };

            var newAccessToken = JwtHelper.GenerateJwtToken(user, _config, claims);

            return new AuthResponse { AccessToken = newAccessToken };
        }

    }

}

using KaryeramAPI.DTOs;
using KaryeramAPI.Models;
using KaryeramAPI.Repositories;
using KaryeramAPI.Helpers;

namespace KaryeramAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
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

            return new AuthResponse
            {
                AccessToken = JwtHelper.GenerateJwtToken(user, _config),
                RefreshToken = JwtHelper.GenerateRefreshToken()
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return new AuthResponse
            {
                AccessToken = JwtHelper.GenerateJwtToken(user, _config),
                RefreshToken = JwtHelper.GenerateRefreshToken()
            };
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = await _userRepository.GetByRefreshTokenAsync(refreshToken);
            if (user == null) throw new Exception("Invalid refresh token");
            var newRefreshToken = JwtHelper.GenerateRefreshToken();
            await _userRepository.UpdateRefreshTokenAsync(user.Id, newRefreshToken);
            var newAccessToken = JwtHelper.GenerateJwtToken(user, _config);

            return new AuthResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

    }

}

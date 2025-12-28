using KaryeramAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace KaryeramAPI.DTOs
{
    public class RegisterRequest
    {
        [Required, MinLength(2)]
        public string FullName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, MinLength(8)]
        public string Password { get; set; } = null!;
    }

    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, MinLength(8)]
        public required string Password { get; set; } = null!;
    }

    public class AuthResponse
    {
        public UserDto User { get; set; } = null!;
        public string AccessToken { get; set; } = string.Empty;
        public int AccessTokenExpiresIn  { get; set; } = 900;
        public string RefreshToken { get; set; } = string.Empty;
    }

    public record UserDto(string Email, string Role);
}

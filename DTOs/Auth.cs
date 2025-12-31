using KaryeramAPI.Models;
using System.ComponentModel.DataAnnotations;
using static KaryeramAPI.Enums.Enums;

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

        [Required]
        public UserRole Role { get; set; } = UserRole.JobSeeker;
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
        public string AccessToken { get; set; } = string.Empty;
        public int AccessTokenExpiresIn  { get; set; } = 900;
    }

    public class UserProfileResponse
    {
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class UserAccountResponse
    {
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

}

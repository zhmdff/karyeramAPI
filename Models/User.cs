namespace KaryeramAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; } = DateTime.UtcNow.AddDays(90);


        public UserRole UserRole { get; set; } = UserRole.Guest;
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public EmployerProfile? EmployerProfile { get; set; }
        public JobSeekerProfile? JobSeekerProfile { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Employer,
        JobSeeker,
        Guest
    }
}

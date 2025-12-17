namespace KaryeramAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRole UserRole { get; set; } = UserRole.Guest;
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? ProfileId { get; set; }
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

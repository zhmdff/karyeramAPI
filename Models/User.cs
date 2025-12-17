namespace KaryeramAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public UserRole? UserRole { get; set; }
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        
    }

    public enum UserRole
    {
        Admin,
        Employer,
        JobSeeker,
        Guest
    }
}

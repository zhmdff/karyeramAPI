namespace KaryeramAPI.Models
{
    public class EmployerProfile
    {
        public int Id { get; set; }
        public string? Industry { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? LogoUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Job> PostedJobs { get; set; } = new List<Job>();
    }
}

using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace KaryeramAPI.Models
{
    public class JobSeekerProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public Resume? Resume { get; set; }
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}

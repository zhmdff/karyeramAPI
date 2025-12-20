using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace KaryeramAPI.Models
{
    public class JobSeekerProfile
    {
        public int Id { get; set; }
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

    public enum EducationLevel
    {
        NoEducation = 1,
        Secondary = 2,
        IncompleteHigher = 3,
        Higher = 4,
        Academic = 5
    }

    public enum ExperienceLevel
    {
        NoExperience = 1,
        LessThanOneYear = 2,
        OneToThreeYears = 3,
        ThreeToFiveYears = 4,
        MoreThanFiveYears = 5
    }

    public enum JobType
    {
        FullTime = 1,
        PartTime = 2,
        Internship = 3,
        Freelance = 4
    }
}

using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace KaryeramAPI.Models
{
    public class JobSeekerProfile
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string? FullName { get; set; } = null;

        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        [MaxLength(4000)]

        public string? Skills { get; set; }

        public EducationLevel? Education { get; set; } = EducationLevel.NoEducation;
        public string? EducationText { get; set; }

        [MaxLength(2000)]
        public string? Certificates { get; set; }

        public ExperienceLevel? Experience { get; set; } = ExperienceLevel.NoExperience;
        public string? ExperienceText { get; set; }

        public JobType? DesiredJobType { get; set; } = JobType.FullTime;
        public string? AboutMe { get; set; }
        public string? Address { get; set; }
        public int? LocationId { get; set; }
        public virtual Location? Location { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? ProfilePicture { get; set; } = null;
        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }

    public enum EducationLevel
    {
        [Display(Name = "Təhsilsiz")]
        NoEducation = 1,

        [Display(Name = "Orta")]
        Secondary = 2,

        [Display(Name = "Natamam Ali")]
        IncompleteHigher = 3,

        [Display(Name = "Ali")]
        Higher = 4,

        [Display(Name = "Elmi")]
        Academic = 5
    }

    public enum ExperienceLevel
    {
        [Display(Name = "Təcrübəsiz")]
        NoExperience = 1,

        [Display(Name = "Bir ildən az təcrübə")]
        LessThanOneYear = 2,

        [Display(Name = "1-3 il arası təcrübə")]
        OneToThreeYears = 3,

        [Display(Name = "3-4 il arası təcrübə")]
        ThreeToFiveYears = 4,

        [Display(Name = "Beş ildən çox təcrübə")]
        MoreThanFiveYears = 5
    }

    public enum JobType
    {
        [Display(Name = "Tam ştat")]
        FullTime = 1,

        [Display(Name = "Yarım ştat")]
        PartTime = 2,

        [Display(Name = "Təcrübəçi")]
        Internship = 3,

        [Display(Name = "Freelance")]
        Freelance = 4
    }
}

using static KaryeramAPI.Enums.Enums;

namespace KaryeramAPI.Models
{
    public class Resume
    {
        public int Id { get; set; }

        public string? AboutMe { get; set; }
        public string? Skills { get; set; }
        public string? Address { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        public EducationLevel Education { get; set; } = EducationLevel.NoEducation;
        public ExperienceLevel Experience { get; set; } = ExperienceLevel.NoExperience;
        public JobType DesiredJobType { get; set; } = JobType.FullTime;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; }

        public int JobSeekerProfileId { get; set; }
        public JobSeekerProfile JobSeeker { get; set; } = null!;
    }
}

using Microsoft.AspNetCore.Builder;

namespace KaryeramAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;

        // Company info
        public int EmployerProfileId { get; set; }
        public EmployerProfile EmployerProfile { get; set; } = null!;

        //Relation
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public string? LocationText { get; set; }

        // Salary & age
        public decimal? Salary { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        // Enums
        public JobType JobType { get; set; } = JobType.FullTime;
        public ExperienceLevel ExperienceLevel { get; set; } = ExperienceLevel.NoExperience;
        public EducationLevel EducationLevel { get; set; } = EducationLevel.NoEducation;

        // Other
        public string? Skills { get; set; } = string.Empty;
        public bool IsPremium { get; set; } = false;
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; } = true;

        public int ViewCount { get; set; } = 0;
        public int ApplicationCount { get; set; } = 0;

        // Relations
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

        // Category links
        public int? CategoryId { get; set; }
        public JobCategory? Category { get; set; }

        public int? SubCategoryId { get; set; }
        public JobSubcategory? SubCategory { get; set; }

    }

}

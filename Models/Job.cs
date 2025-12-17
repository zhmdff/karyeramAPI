using Microsoft.AspNetCore.Builder;

namespace KaryeramAPI.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;

        // Company info
        public string CompanyName { get; set; } = string.Empty;
        public string? CompanyWebsite { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        //Relation
        public int? LocationId { get; set; }
        public Location? Location { get; set; } = null!;
        public string? LocationStr { get; set; } = null!;

        // Salary & age
        public decimal? Salary { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        // Enums
        public JobType? JobType { get; set; }
        public ExperienceLevel? ExperienceLevel { get; set; }
        public EducationLevel? EducationLevel { get; set; }

        // Other
        public string? Skills { get; set; } = string.Empty;
        public bool IsPremium { get; set; } = false;
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;

        public int ViewCount { get; set; } = 0;
        public int ApplicationCount { get; set; } = 0;

        // Relations
        public int EmployerProfileId { get; set; }
        public virtual EmployerProfile? Employer { get; set; } = null!;

        public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

        // Category links
        public int? CategoryId { get; set; }
        public virtual JobCategory? Category { get; set; } = null!;

        public int? SubCategoryId { get; set; }
        public virtual JobSubcategory? SubCategory { get; set; } = null!;

    }

}

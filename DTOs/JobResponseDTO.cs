using static KaryeramAPI.Enums.Enums;

namespace KaryeramAPI.DTOs
{
    public sealed class JobResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;

        // Employer
        public int EmployerProfileId { get; set; }
        public string? EmployerName { get; set; }

        // Location
        public int? LocationId { get; set; }
        public string? LocationText { get; set; }

        // Salary & age
        public decimal? Salary { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        // Enums
        public JobType JobType { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public EducationLevel EducationLevel { get; set; }

        // Other
        public string? Skills { get; set; }
        public bool IsPremium { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }

        public int ViewCount { get; set; }
        public int ApplicationCount { get; set; }

        // Category
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public int? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
    }

}

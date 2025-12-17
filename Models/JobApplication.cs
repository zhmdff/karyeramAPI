namespace KaryeramAPI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public virtual Job Job { get; set; } = null!;

        public int JobSeekerProfileId { get; set; }
        public virtual JobSeekerProfile JobSeeker { get; set; } = null!;

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public string? CoverLetter { get; set; }
        public string? ResumePath { get; set; }

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        public DateTime StatusChangedAt { get; set; }
        public DateTime CreatedAt = DateTime.UtcNow;
    }

    public enum ApplicationStatus
    {
        Pending,
        Reviewed,
        Interview,
        Offered,
        Rejected
    }
}

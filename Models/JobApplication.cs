namespace KaryeramAPI.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; } = null!;

        public int JobSeekerProfileId { get; set; }
        public JobSeekerProfile JobSeekerProfile { get; set; } = null!;

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public string? CoverLetter { get; set; }
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime StatusChangedAt { get; set; }
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

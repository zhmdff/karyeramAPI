namespace KaryeramAPI.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public ExperienceLevel ExperienceLevel { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        //Relations
        public int JobSeekerProfileId { get; set; }
        public virtual JobSeekerProfile JobSeeker { get; set; } = null!;
    }
}

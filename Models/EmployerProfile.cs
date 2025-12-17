namespace KaryeramAPI.Models
{
    public class EmployerProfile
    {
        public int Id { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? Industry { get; set; }
        public string? Website { get; set; }
        public string? ProfilePicture { get; set; } = null;


        public string UserId { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        //public virtual ICollection<Job> PostedJobs { get; set; } = new List<Job>();
    }
}

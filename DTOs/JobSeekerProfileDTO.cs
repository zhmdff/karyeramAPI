using System.ComponentModel.DataAnnotations;

namespace KaryeramAPI.DTOs
{
    public class JobSeekerProfileDTO
    {
        public string FullName { get; set; } = null!;
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }

}

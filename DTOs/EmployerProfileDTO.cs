using System.ComponentModel.DataAnnotations;

namespace KaryeramAPI.DTOs
{
    public class EmployerProfileDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? Industry { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? LogoUrl { get; set; }
    }
}

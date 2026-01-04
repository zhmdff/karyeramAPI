namespace KaryeramAPI.DTOs
{
    public class CreateJobRequest
    {
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
    }
}

namespace KaryeramAPI.Models
{
    public class JobSubcategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int CategoryId { get; set; }
        public JobCategory Category { get; set; } = null!;

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}

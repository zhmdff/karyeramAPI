namespace KaryeramAPI.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<JobSubcategory> SubCategories { get; set; } = new List<JobSubcategory>();
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}

namespace KaryeramAPI.Models
{
    public class JobSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int JobCategoryId { get; set; }
        public virtual JobCategory Category { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}

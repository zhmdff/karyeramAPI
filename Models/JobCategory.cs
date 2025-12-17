namespace KaryeramAPI.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<JobSubcategory> SubCategories { get; set; } = new List<JobSubcategory>();
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}

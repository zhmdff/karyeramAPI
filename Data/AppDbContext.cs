using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobSubcategory> JobSubcategories { get; set; }

        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<UserNotification> UserNotifications { get; set; } = null!;
        public DbSet<NotificationPreference> NotificationPreferences { get; set; } = null!;

        public virtual ICollection<Job> PostedJobs { get; set; } = new List<Job>();
        public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Notification>(b =>
            {
                b.ToTable("notifications");
                b.HasKey(x => x.Id);
                b.Property(x => x.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            });

            builder.Entity<UserNotification>(b =>
            {
                b.ToTable("user_notifications");
                b.HasKey(x => x.Id);
                b.HasIndex(x => new { x.UserId, x.IsRead, x.CreatedAt });
                b.HasIndex(x => new { x.UserId, x.CreatedAt });
                b.HasIndex(x => x.NotificationId);
                b.HasOne(x => x.Notification).WithMany(n => n.UserNotifications).HasForeignKey(x => x.NotificationId).OnDelete(DeleteBehavior.Cascade);
                b.HasAlternateKey(nameof(UserNotification.NotificationId), nameof(UserNotification.UserId)); // unique(notification_id, user_id)
            });

            builder.Entity<NotificationPreference>(b =>
            {
                b.ToTable("notification_preferences");
                b.HasKey(x => x.UserId);
            });


            builder.Entity<Job>()
                .Property(j => j.Salary)
                .HasColumnType("decimal(18,2)");

            builder.Entity<JobSeekerProfile>()
                .Property(p => p.SalaryMax)
                .HasColumnType("decimal(18,2)");

            builder.Entity<JobSeekerProfile>()
                .Property(p => p.SalaryMin)
                .HasColumnType("decimal(18,2)");

            // Job -> EmployerProfile
            builder.Entity<Job>()
                .HasOne(j => j.SubCategory)
                .WithMany()
                .HasForeignKey(j => j.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Job → JobApplication
            builder.Entity<JobApplication>()
                .HasOne(ja => ja.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(ja => ja.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobSeekerProfile → JobApplication
            builder.Entity<JobApplication>()
                .HasOne(ja => ja.JobSeeker)
                .WithMany(js => js.Applications)
                .HasForeignKey(ja => ja.JobSeekerProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobSeekerProfile enum conversions
            builder.Entity<JobSeekerProfile>()
                .Property(p => p.Education)
                .HasConversion<string>();
            builder.Entity<JobSeekerProfile>()
                .Property(p => p.Experience)
                .HasConversion<string>();
            builder.Entity<JobSeekerProfile>()
                .Property(p => p.DesiredJobType)
                .HasConversion<string>();

            // EmployerProfile -> ApplicationUser
            builder.Entity<EmployerProfile>()
                .HasOne(e => e.User)
                .WithMany() // no collection in ApplicationUser
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobSeekerProfile -> ApplicationUser
            builder.Entity<JobSeekerProfile>()
                .HasOne(js => js.User)
                .WithMany() // no collection in ApplicationUser
                .HasForeignKey(js => js.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}

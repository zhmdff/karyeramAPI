using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace KaryeramAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobSubcategory> JobSubcategories { get; set; }

        //public DbSet<Notification> Notifications { get; set; } = null!;
        //public DbSet<UserNotification> UserNotifications { get; set; } = null!;
        //public DbSet<NotificationPreference> NotificationPreferences { get; set; } = null!;

        public virtual ICollection<Job> PostedJobs { get; set; } = new List<Job>();
        public virtual ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // EmployerProfile 
            builder.Entity<EmployerProfile>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Industry)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyWebsite)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogoUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired(false);

                entity.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<EmployerProfile>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.PostedJobs)
                    .WithOne(j => j.EmployerProfile)
                    .HasForeignKey(j => j.EmployerProfileId);
            });


            builder.Entity<JobSeekerProfile>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePictureUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired(false);

                entity.HasOne(e => e.User)
                    .WithOne()
                    .HasForeignKey<JobSeekerProfile>(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Applications)
                    .WithOne(a => a.JobSeekerProfile)
                    .HasForeignKey(a => a.JobSeekerProfileId);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(e => e.EmployerProfile)
                    .WithOne(p => p.User)
                    .HasForeignKey<EmployerProfile>(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.JobSeekerProfile)
                    .WithOne(p => p.User)
                    .HasForeignKey<JobSeekerProfile>(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshTokenExpiry)
                    .HasDefaultValueSql("DATEADD(DAY, 30, GETUTCDATE())");
            });

            builder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasDefaultValue(string.Empty);

                entity.Property(e => e.Requirements)
                    .HasDefaultValue(string.Empty);

                entity.Property(e => e.Skills)
                    .HasDefaultValue(string.Empty);

                entity.Property(e => e.PostedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.Property(e => e.ViewCount)
                    .HasDefaultValue(0);

                entity.Property(e => e.ApplicationCount)
                    .HasDefaultValue(0);

                // Relationships
                entity.HasOne(e => e.EmployerProfile)
                    .WithMany(p => p.PostedJobs)
                    .HasForeignKey(e => e.EmployerProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Category)
                    .WithMany()
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.SubCategory)
                    .WithMany()
                    .HasForeignKey(e => e.SubCategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Applications)
                    .WithOne(a => a.Job)
                    .HasForeignKey(a => a.JobId);

                entity.Property(j => j.Salary)
                    .HasColumnType("decimal(18,2)");
            });

            builder.Entity<JobApplication>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CoverLetter)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.AppliedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.Status)
                    .HasDefaultValue(ApplicationStatus.Pending);

                entity.HasOne(e => e.Job)
                    .WithMany(j => j.Applications)
                    .HasForeignKey(e => e.JobId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.JobSeekerProfile)
                    .WithMany(s => s.Applications)
                    .HasForeignKey(e => e.JobSeekerProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Resume)
                    .WithMany()
                    .HasForeignKey(e => e.ResumeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JobCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.HasMany(e => e.SubCategories)
                    .WithOne(sc => sc.Category)
                    .HasForeignKey(sc => sc.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<JobSubcategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            builder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();
            });

            builder.Entity<Resume>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.AboutMe)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Skills)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.SalaryMin).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SalaryMax).HasColumnType("decimal(18,2)");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(r => r.JobSeeker)
                    .WithOne(s => s.Resume)
                    .HasForeignKey<Resume>(r => r.JobSeekerProfileId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId)
                    .OnDelete(DeleteBehavior.SetNull);
            });


        }

    }
}

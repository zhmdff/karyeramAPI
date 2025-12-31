using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI.Repositories
{
    public class JobSeekerRepository : IJobSeekerRepository
    {
        private readonly AppDbContext _context;
        public JobSeekerRepository(AppDbContext context) => _context = context;

        public Task<JobSeekerProfile?> GetProfileByIdAsync(int id) => _context.JobSeekerProfiles.FirstOrDefaultAsync(u => u.Id == id);

        public Task<JobSeekerProfile?> GetProfileByUserIdAsync(int userId) => _context.JobSeekerProfiles.FirstOrDefaultAsync(u => u.UserId == userId);

        public async Task<JobSeekerProfile> AddAsync(JobSeekerProfile jobSeekerProfile)
        {
            _context.JobSeekerProfiles.Add(jobSeekerProfile);
            await _context.SaveChangesAsync();
            return jobSeekerProfile;
        }
    }
}

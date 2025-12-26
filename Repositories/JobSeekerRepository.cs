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

        public async Task AddAsync(JobSeekerProfile jobSeekerProfile)
        {
            _context.JobSeekerProfiles.Add(jobSeekerProfile);
            await _context.SaveChangesAsync();
        }
    }
}

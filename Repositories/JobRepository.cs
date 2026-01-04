using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<List<Job>> GetJobsAsync()
        {
            var jobs = await _context.Jobs.Where(j => j.IsActive == true).AsNoTracking().ToListAsync();
            return jobs;
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            var jobs = await _context.Jobs.AsNoTracking().ToListAsync();
            return jobs;
        }
    }
}

using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly AppDbContext _context;
        public EmployerRepository(AppDbContext context) => _context = context;

        public Task<EmployerProfile?> GetProfileByIdAsync(int id) => _context.EmployerProfiles.FirstOrDefaultAsync(u => u.Id == id);

        public Task<EmployerProfile?> GetProfileByUserIdAsync(int userId) => _context.EmployerProfiles.FirstOrDefaultAsync(u => u.UserId == userId);

        public async Task<EmployerProfile> AddAsync(EmployerProfile employerProfile)
        {
            _context.EmployerProfiles.Add(employerProfile);
            await _context.SaveChangesAsync();
            return employerProfile;
        }
    }
}

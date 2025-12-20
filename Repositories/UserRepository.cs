using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public Task<bool> ExistsByEmailAsync(string email) =>
            _context.Users.AnyAsync(u => u.Email == email);

        public Task<User?> GetByEmailAsync(string email) =>
            _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task<User?> GetByRefreshTokenAsync(string refreshToken) =>
            _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

        public async Task UpdateRefreshTokenAsync(int userId, string newRefreshToken)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return;
            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();
        }

    }

}

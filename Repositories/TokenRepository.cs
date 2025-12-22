using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaryeramAPI.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext _context;
        public TokenRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(RefreshToken token)
        {
            _context.RefreshTokens.Add(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetAsync(int userId, string rawToken)
        {
            var tokens = await _context.RefreshTokens
                .Where(t => t.UserId == userId && t.ExpiresAt > DateTime.UtcNow)
                .ToListAsync();

            return tokens.FirstOrDefault(t =>
                BCrypt.Net.BCrypt.Verify(rawToken, t.TokenHash));
        }

        public async Task DeleteAsync(int userId, string rawToken)
        {
            var token = await GetAsync(userId, rawToken);
            if (token == null) return;

            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync();
        }
    }
}

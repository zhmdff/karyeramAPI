using KaryeramAPI.Data;
using KaryeramAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

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

        public async Task<RefreshToken?> GetRefreshTokenAsync(string tokenHash)
        {
            return await _context.RefreshTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.TokenHash == tokenHash && !t.IsRevoked && t.ExpiresAt > DateTime.UtcNow);
        }

        public async Task<RefreshToken?> GetRefreshTokenByIdAsync(int userId, string rawToken)
        {
            var hashedToken = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(rawToken)));
            var token = await _context.RefreshTokens
                .Where(t => t.UserId == userId && !t.IsRevoked && t.TokenHash == hashedToken)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (token == null || token.ExpiresAt < DateTime.UtcNow)
            {
                return null;
            }

            return token;
        }

        //public async Task<User?> GetByTokenAsync(string rawToken)
        //{
        //    var token = await _context.RefreshTokens
        //        .Include(t => t.User)
        //        .Where(t => t.ExpiresAt > DateTime.UtcNow)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(t => BCrypt.Net.BCrypt.Verify(rawToken, t.TokenHash));

        //    return token?.User;
        //}

        public async Task RevokeAsync(int tokenId)
        {
            var token = await _context.RefreshTokens.FindAsync(tokenId);
            if (token == null) return;

            token.IsRevoked = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, string rawToken)
        {
            var token = await GetRefreshTokenByIdAsync(userId, rawToken);
            if (token == null) return;

            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync();
        }

    }
}

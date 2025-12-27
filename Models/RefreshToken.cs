namespace KaryeramAPI.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TokenHash { get; set; } = null!;
        public bool IsRevoked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; } = null!;

        public bool IsExpired => DateTime.UtcNow > ExpiresAt;
    }

}

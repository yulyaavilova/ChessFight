using Microsoft.AspNetCore.Identity;

namespace ChessFight.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public int EloRating { get; set; } = 1000;
        public int Coins { get; set; } = 0;
        public string? AvatarUrl { get; set; }
        public string? BannerUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<UserSkin> OwnedSkins { get; set; } = new();

        public List<Game> GamesAsPlayer1 { get; set; } = new();
        public List<Game> GamesAsPlayer2 { get; set; } = new();
        public List<Game> GamesWon { get; set; } = new();
    }
}

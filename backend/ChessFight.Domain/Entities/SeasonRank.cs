
namespace ChessFight.Domain.Entities
{
    public class SeasonRank
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string Name { get; set; } = null!; // "Золото", "Серебро"
        public int MinEloRating { get; set; } // 1000
        public int MaxEloRating { get; set; } // 1499
        public string ColorCode { get; set; } = null!; // "#FFD700" (золотой)

        // Награда за достижение ранга
        public int? RewardCoins { get; set; } // 100 монет
        public string? RewardBannerUrl { get; set; } // Иконка ранга
    }
}

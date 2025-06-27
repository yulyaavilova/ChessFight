
namespace ChessFight.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        
        public int Player1Id { get; set; }
        public User Player1 { get; set; } = null!;

        public int Player2Id { get; set; }
        public User Player2 { get; set; } = null!;

        public string CurrentFen { get; set; } = null!;
        public GameStatus Status { get; set; }
        public int? WinnerId { get; set; }
        public User? Winner { get; set; }
        public bool IsRanked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? FinishedAt { get; set; }
        public int TimeControlId { get; set; }
        public TimeControl? TimeControl { get; set; }
    }
}

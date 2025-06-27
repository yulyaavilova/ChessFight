
namespace ChessFight.Domain.Entities
{
    public class Move
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string FromSquare { get; set; } = null!;
        public string ToSquare { get; set; } = null!;
        public string ChessPiece { get; set; } = null!;// "q", "r", "b", "n"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

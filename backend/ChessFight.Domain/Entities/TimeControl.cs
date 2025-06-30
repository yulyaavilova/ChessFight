
namespace ChessFight.Domain.Entities
{
    public class TimeControl
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int InitialTimeMinutes { get; set; }
        public int IncrementSeconds { get; set; }
    }
}

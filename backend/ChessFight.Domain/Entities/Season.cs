
namespace ChessFight.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // "Лето 2024"
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string? BadgeIconUrl { get; set; } // Иконка сезона
    }
}

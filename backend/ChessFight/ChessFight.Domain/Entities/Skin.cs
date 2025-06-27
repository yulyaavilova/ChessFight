
namespace ChessFight.Domain.Entities
{
    public class Skin
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ChessPiece { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Price { get; set; }
    }
}

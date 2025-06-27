
namespace ChessFight.Domain.Entities
{
    public class UserSkin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int SkinId { get; set; }
        public Skin Skin { get; set; } = null!;

        public bool IsSelected { get; set; }
        public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
    }
}


using ChessFight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessFight.Infrastructure.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(game => game.Player1)
                .WithMany(player => player.GamesAsPlayer1)
                .HasForeignKey(game => game.Player1Id)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(game => game.Player2)
                .WithMany(player => player.GamesAsPlayer2)
                .HasForeignKey(game => game.Player2Id)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(game => game.Winner)
                .WithMany(player => player.GamesWon)
                .HasForeignKey(game => game.WinnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}

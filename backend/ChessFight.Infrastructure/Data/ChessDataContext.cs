using ChessFight.Domain.Entities;
using ChessFight.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChessFight.Infrastructure.Data
{
    public class ChessDataContext(DbContextOptions<ChessDataContext> options) 
        : IdentityDbContext<User, IdentityRole<int>, int>(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<TimeControl> TimeControls => Set<TimeControl>();
        public DbSet<Move> Moves => Set<Move>();
        public DbSet<Season> Seasons => Set<Season>();
        public DbSet<SeasonRank> SeasonRanks => Set<SeasonRank>();
        public DbSet<Skin> Skins => Set<Skin>();
        public DbSet<UserSkin> UserSkins => Set<UserSkin>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());

        }
    }
}

using ChessFight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessFight.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TournamentForm.Domain.Entities;

namespace TournamentForm.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Email);

            builder.Property(t => t.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(200);
        }
    }
}
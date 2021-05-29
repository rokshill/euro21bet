using Euro21bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euro21bet.Infrastructure.Persistence.Configurations
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
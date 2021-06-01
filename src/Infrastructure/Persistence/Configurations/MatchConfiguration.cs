using Euro21bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euro21bet.Infrastructure.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(e => e.HomeTeam).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.AwayTeam).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
using Euro21bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euro21bet.Infrastructure.Persistence.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(e => e.HomeTeam).WithMany(e => e.HomeMatches).HasForeignKey(e => e.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.AwayTeam).WithMany(e => e.AwayMatches).HasForeignKey(e => e.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(e => e.Round).WithMany(e => e.Matches);
            builder.HasOne(e => e.Group).WithMany(e => e.Matches).IsRequired(false);
        }
    }
}
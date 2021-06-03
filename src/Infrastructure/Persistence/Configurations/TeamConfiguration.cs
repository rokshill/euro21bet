using Euro21bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euro21bet.Infrastructure.Persistence.Configurations
{
    public class TeamConfiguration
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasOne(e => e.Standings).WithOne().HasForeignKey<Standings>(e => e.TeamId).OnDelete(DeleteBehavior.Restrict);
            builder.Navigation(e => e.Standings).UsePropertyAccessMode(PropertyAccessMode.Property);
            builder.HasOne(e => e.Group).WithMany(e => e.Teams).OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(e => e.HomeMatches).WithOne(e => e.HomeTeam).HasForeignKey(e => e.HomeTeamId);
            builder.HasMany(e => e.AwayMatches).WithOne(e => e.AwayTeam).HasForeignKey(e => e.AwayTeamId);
        }
    }
}
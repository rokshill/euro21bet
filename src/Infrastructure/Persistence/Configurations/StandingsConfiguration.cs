using Euro21bet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euro21bet.Infrastructure.Persistence.Configurations
{
    public class StandingsConfiguration
    {
        public void Configure(EntityTypeBuilder<Standings> builder)
        {
        }
    }
}
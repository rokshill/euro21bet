using System.Collections.Generic;

namespace Euro21bet.Application.Standings.Queries
{
    public class StandingsVm

    {
        public string Name { get; set; }
        public List<StandingsRecord> Records { get; set; } = new();
    }
}
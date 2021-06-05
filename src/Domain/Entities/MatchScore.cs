using Euro21bet.Domain.Common;
using Euro21bet.Domain.Enums;

namespace Euro21bet.Domain.Entities
{
    public class MatchScore : AuditableEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }

        public MatchScoreType Type { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public bool Confirmed { get; set; }
    }
}
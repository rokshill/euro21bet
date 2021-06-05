using Euro21bet.Domain.Common;
using Euro21bet.Domain.Enums;

namespace Euro21bet.Domain.Entities
{
    public class MatchBet : AuditableEntity
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public int Points { get; set; }
    }
}
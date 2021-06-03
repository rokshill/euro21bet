using Euro21bet.Domain.Common;

namespace Euro21bet.Domain.Entities
{
    public class Standings : AuditableEntity
    {
        public int TeamId { get; set; }
        
        public int Position { get; set; }
        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Loss { get; set; }

        public int GoalFor { get; set; }
        public int GoalAgainst { get; set; }
        public int GoalDifference => GoalFor - GoalAgainst;
        public int Points { get; set; }
    }
}
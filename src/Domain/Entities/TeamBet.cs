using Euro21bet.Domain.Common;
using Euro21bet.Domain.Enums;

namespace Euro21bet.Domain.Entities
{
    public class TeamBet : AuditableEntity
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public BetTeamType Type { get; set; }


        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public int? RoundId { get; set; }
        public Round? Round { get; set; }

        public int Points { get; set; }

    }
}
using System;
using Euro21bet.Domain.Common;
using Euro21bet.Domain.Enums;

namespace Euro21bet.Domain.Entities
{
    public class Match : Entity
    {
        private Match() { } //EF constructor

        public Match(DateTime matchDateTime, Team homeTeam, Team awayTeam)
        {
            MatchDateTime = matchDateTime;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public DateTime MatchDateTime { get; private set; }
        public RoundMatchType Type { get; set; }

        public int HomeTeamId { get; private set; }
        public Team HomeTeam { get; private set; }
        
        public int AwayTeamId { get; private set; }
        public Team AwayTeam { get; private set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }
    }
}
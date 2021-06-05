using System.Collections.Generic;
using Ardalis.GuardClauses;
using Euro21bet.Domain.Common;

namespace Euro21bet.Domain.Entities
{
    public class Team : Entity
    {
        private Team() { } //EF constructor

        public Team(string name, string shortName, string crestUrl, Group group)
        {
            Name =  Guard.Against.NullOrWhiteSpace(name, nameof(name));
            ShortName = Guard.Against.NullOrWhiteSpace(shortName, nameof(shortName));
            CrestUrl = Guard.Against.NullOrWhiteSpace(crestUrl, nameof(crestUrl));

            Group = group;
            Standings = new Standings();
        }

        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string CrestUrl { get; private set; }
        public Group Group { get; set; }
        public Standings Standings { get; set; }
        public IEnumerable<Match> HomeMatches { get; set; }
        public IEnumerable<Match> AwayMatches { get; set; }
        public IEnumerable<TeamBet> Bets { get; set; }

    }
}
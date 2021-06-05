using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace Euro21bet.Domain.Entities
{
    public class User
    {
        private User(){} //EF constructor

        public User(string email, string nickname, string name, string picture)
        {
            Nickname = nickname;
            Picture = picture;
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public string Picture { get; private set; }
        public IEnumerable<MatchBet> MatchBets { get; set; } 
        public IEnumerable<TeamBet> TeamBets { get; set; } 
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Euro21bet.Domain.Common;
using Euro21bet.Domain.Enums;

namespace Euro21bet.Domain.Entities
{
    public class Round : Entity
    {
        private readonly Collection<Match> _matches = new();

        private Round() { } //EF constructor

        public Round(string name, RoundMatchType type)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Type = type;
        }

        public string Name { get; private set; }
        public RoundMatchType Type { get; private set; }
        public IEnumerable<Match> Matches => _matches;

        public void AddMatch(Match match)
        {
            match.Round = this;
            match.RoundId = Id;
            match.Type = this.Type;
            _matches.Add(match);
        }

    }
}
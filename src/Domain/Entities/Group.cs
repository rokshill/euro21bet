using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using Euro21bet.Domain.Common;
using Euro21bet.Domain.Enums;

namespace Euro21bet.Domain.Entities
{
    public class Group : Entity
    {
        private readonly Collection<Team> _teams = new();
        private readonly Collection<Match> _matches = new();
        
        private Group() { } //EF constructor

        public Group(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public string Name { get; private set; }
        public IEnumerable<Team> Teams => _teams;
        public IEnumerable<Match> Matches => _matches;

        public void AddTeam(Team team)
        {
            team.Group = this;
            _teams.Add(team);
        }

        public void AddMatch(Match match)
        {
            if (match.HomeTeam.Group != this || match.AwayTeam.Group != this)
            {
                throw new ValidationException("The match group does not match the team group.");
            }

            match.Group = this;
            match.GroupId = Id;
            match.Type = RoundMatchType.Group;
            _matches.Add(match);
        }
    }
}
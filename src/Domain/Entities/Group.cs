using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Euro21bet.Domain.Common;

namespace Euro21bet.Domain.Entities
{
    public class Group : Entity
    {
        private readonly Collection<Team> _teams = new();
        
        private Group() { } //EF constructor

        public Group(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }

        public string Name { get; private set; }
        public IEnumerable<Team> Teams => _teams;

        public void AddTeam(Team team)
        {
            team.Group = this;
            team.GroupId = Id;
            _teams.Add(team);
        }
    }
}
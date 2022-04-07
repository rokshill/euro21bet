using System;
using Ardalis.GuardClauses;
using TournamentForm.Domain.Common;

namespace TournamentForm.Domain.Entities
{
    public class Item : Entity
    {
        private Item() { } //EF constructor

        public Item(string title, string description)
        {
             Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
             Description = Guard.Against.NullOrWhiteSpace(description, nameof(description));
             ItemDateTime = DateTime.UtcNow;
        }

        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime ItemDateTime { get; private set; } = DateTime.UtcNow;
    }
}
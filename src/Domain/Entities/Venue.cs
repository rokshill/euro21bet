using Ardalis.GuardClauses;
using Euro21bet.Domain.Common;

namespace Euro21bet.Domain.Entities
{
    public class Venue : Entity
    {
        private Venue() { } //EF constructor

        public Venue(string name, int capacity, string gMapUrl)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Capacity = Guard.Against.NegativeOrZero(capacity, nameof(capacity));
            GMapUrl = Guard.Against.NullOrWhiteSpace(gMapUrl, nameof(gMapUrl));
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public string GMapUrl { get; private set; }
    }
}
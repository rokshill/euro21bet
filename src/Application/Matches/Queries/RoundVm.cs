using System.Collections.Generic;
using Euro21bet.Application.Common.Mappings;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Application.Matches.Queries
{
    public class RoundVm : IMapFrom<Round>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IList<MatchVm> Matches { get; set; } = new List<MatchVm>();
    }
}
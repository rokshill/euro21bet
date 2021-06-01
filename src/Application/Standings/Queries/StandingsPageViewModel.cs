using System.Collections.Generic;
using AutoMapper;
using Euro21bet.Application.Common.Mappings;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Application.Standings.Queries
{
    public class StandingsPageViewModel
    {
        public List<StandingsViewModel> Standings { get; set; } = new();
    }

    public class StandingsViewModel
    {
        public string Name { get; set; }
        public List<StandingsRecord> Records { get; set; } = new();
    }

    public class StandingsRecord : IMapFrom<Team>
    {
        public int Position { get; set; }
        public string CrestUrl { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }

        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Loss { get; set; }
        public int GoalFor { get; set; }
        public int GoalAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Team, StandingsRecord>()
        //        .ForMember(d => d.CrestUrl, opt => opt.MapFrom(s => s.));
        //}
    }

}
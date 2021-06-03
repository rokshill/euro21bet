using System;
using AutoMapper;
using Euro21bet.Application.Common.Mappings;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Application.Matches.Queries
{
    public class MatchVm : IMapFrom<Match>
    {
        public int Id { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Type { get; set; }
        public TeamVm HomeTeam { get; set; }
        public TeamVm AwayTeam { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Match, MatchVm>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => Enum.GetName(s.Type)));
        }
    }
}
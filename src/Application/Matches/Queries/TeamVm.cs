using AutoMapper;
using Euro21bet.Application.Common.Mappings;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Application.Matches.Queries
{
    public class TeamVm : IMapFrom<Team>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CrestUrl { get; set; }
        public int GroupId { get; set; }
        public string Group { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamVm>()
                .ForMember(d => d.Group, opt => opt.MapFrom(s => s.Group.Name));
        }
    }
}
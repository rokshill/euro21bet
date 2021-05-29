using AutoMapper;
using Euro21bet.Application.Common.Mappings;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Application.Teams.Queries
{
    public class TeamDto : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CrestUrl { get; set; }
        public string Group { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Team, TeamDto>()
                .ForMember(d => d.Group, opt => opt.MapFrom(s => s.Group.Name));
        }
    }
}
using TournamentForm.Application.Common.Mappings;
using TournamentForm.Domain.Entities;

namespace TournamentForm.Application.Users
{
    public class UserDto : IMapFrom<User>
    {
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
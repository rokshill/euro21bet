using System.Collections.Generic;
using System.Threading.Tasks;

namespace TournamentForm.Application.Common.Interfaces.Identity
{
    public interface IUserService
    {
        Task EnsureUserExists(string email, string nickname, string name, string picture, List<string> permissions);
    }
}
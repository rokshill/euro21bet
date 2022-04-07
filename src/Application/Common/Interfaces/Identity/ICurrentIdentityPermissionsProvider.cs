using TournamentForm.Application.Common.Models.Authorization;

namespace TournamentForm.Application.Common.Interfaces.Identity
{
    public interface ICurrentIdentityPermissionsProvider
    {
        bool HasPermission(Permission permission);
    }
}
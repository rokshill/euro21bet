using Euro21bet.Application.Common.Models.Authorization;

namespace Euro21bet.Application.Common.Interfaces.Identity
{
    public interface ICurrentIdentityPermissionsProvider
    {
        bool HasPermission(Permission permission);
    }
}
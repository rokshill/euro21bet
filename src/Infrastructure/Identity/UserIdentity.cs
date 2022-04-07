using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using IdentityServer4.Extensions;
using TournamentForm.Application.Common.Interfaces.Identity;
using TournamentForm.Application.Common.Models.Authorization;
using TournamentForm.Application.Common.Security;

namespace TournamentForm.Infrastructure.Identity
{
    public sealed class UserIdentity : ICurrentIdentityPermissionsProvider, ICurrentIdentityUserProvider, ICurrentIdentitySetter
    {
        public string Email { get; private set; }
        public string Nickname { get; private set; }
        public string Name { get; private set; }

        public string AuditUsername =>
            !Nickname.IsNullOrEmpty() ? Nickname :
            !Name.IsNullOrEmpty() ? Name :
            Email;

        private ICollection<string> Permissions { get; set; }

        public void SetIdentity(string email, string nickname, string name, ICollection<string> permissions)
        {
            if (!permissions.Any() || !permissions.Contains(AppPermission.Admin) && !permissions.Contains(AppPermission.User))
            {
                throw new AuthenticationException($"The user does not have required permissions to use the application! (email: {email})");
            }
            
            Email = email;
            Name = name;
            Nickname = nickname;
            Permissions = permissions;
        }
        
        public bool HasPermission(Permission permission)
        {
            switch (permission)
            {
                case Permission.User:
                    return Permissions.Contains(AppPermission.User);
                case Permission.Admin:
                    return Permissions.Contains(AppPermission.Admin);
                default:
                    return false;
            }
        }
    }
}

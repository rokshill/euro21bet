using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Euro21bet.Application.Common.Interfaces;
using Euro21bet.Application.Common.Interfaces.Identity;
using Euro21bet.Application.Common.Security;
using Euro21bet.Domain.Entities;

namespace Euro21bet.Infrastructure.Identity
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _context;

        public UserService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnsureUserExists(string email, string nickname, string name, string picture, List<string> permissions)
        {
            ValidateUserPermissions(permissions, email);

            var userExists = _context.Users.Any(u => u.Email == email);

            if (!userExists)
            {
                await CreateUserAsync(email, nickname, name, picture);
            }
        }

        public void ValidateUserPermissions(List<string> permissions, string emailClaim)
        {
            if (!permissions.Any() || !permissions.Contains(AppPermission.Admin) && !permissions.Contains(AppPermission.User))
            {
                throw new AuthenticationException($"The user does not have required permissions to use the application! (email: {emailClaim})");
            }
        }

        private async Task CreateUserAsync(string email, string nickname, string name, string picture, CancellationToken cancellationToken = new ())
        {
            Guard.Against.NullOrWhiteSpace(email, nameof(email));
            
            var entity = new User(email, nickname, name, picture);

            await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}

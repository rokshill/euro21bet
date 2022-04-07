using TournamentForm.Application.Common.Interfaces.Identity;

namespace TournamentForm.Infrastructure.Identity
{
    public class EmptyUserProvider : ICurrentIdentityUserProvider
    {
        public static ICurrentIdentityUserProvider Instance => new EmptyUserProvider();

        public string Email => "empty@user.com";
        public string Nickname => "Empty nickname";
        public string Name => "Empty name";
        public string AuditUsername => "Empty audit username";
        public string Username => "Empty user";
    }
}
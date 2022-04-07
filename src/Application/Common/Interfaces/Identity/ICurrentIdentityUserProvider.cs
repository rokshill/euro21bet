namespace TournamentForm.Application.Common.Interfaces.Identity
{
    public interface ICurrentIdentityUserProvider
    {
        string Email { get; }

        string Nickname { get; }

        string Name { get; }

        string AuditUsername { get; }

    }
}
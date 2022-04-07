namespace TournamentForm.Application.Common.Security
{
    public class ClaimsTypesSettings
    {
        public string Guid { get; } = "oid";
        public string Name { get; } = "name";
        public string Email { get; } = "preferred_username";
        public string Scope { get; } = "scope";
        public string Permissions { get; } = "permissions";
        public string Roles { get; } = "roles";
    }
}
namespace TournamentForm.Application.Common.Security
{
    /// <summary>
    /// Contains a list of all the Azure AD app roles this app depends on and works with.
    /// </summary>
    public static class AppPermission
    {
        /// <summary>
        /// User readers can read basic profiles of all users in the directory.
        /// </summary>
        public const string User = "access_as_user";

        /// <summary>
        /// Directory viewers can view objects in the whole directory.
        /// </summary>
        public const string Admin = "access_as_admin";
    }

    /// <summary>
    /// Wrapper class the contain all the authorization policies available in this application.
    /// </summary>
    public static class AuthorizationPolicies
    {
        public const string AssignmentToUserRoleRequired = "AssignmentToUserRoleRequired";
        public const string AssignmentToAdminRoleRequired = "AssignmentToAdminRoleRequired";
    }
}
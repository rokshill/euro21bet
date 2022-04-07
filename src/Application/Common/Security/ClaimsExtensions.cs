using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace TournamentForm.Application.Common.Security
{
    public static class ClaimsExtensions
    {
        public static string GetClaim(this IEnumerable<Claim> claims, string claimTypeName)
        {
            if (string.IsNullOrWhiteSpace(claimTypeName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(claimTypeName));
            }

            return claims
                .SingleOrDefault(c => string.Equals(c.Type, claimTypeName, StringComparison.InvariantCultureIgnoreCase))?
                .Value;
        }

        public static IEnumerable<string> GetClaims(this IEnumerable<Claim> claims, string claimTypeName)
        {
            if (string.IsNullOrWhiteSpace(claimTypeName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(claimTypeName));
            }

            return claims
                .Where(c => string.Equals(c.Type, claimTypeName, StringComparison.InvariantCultureIgnoreCase))
                .Select(c => c.Value);
        }
    }
}
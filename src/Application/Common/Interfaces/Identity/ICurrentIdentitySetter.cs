using System.Collections.Generic;

namespace TournamentForm.Application.Common.Interfaces.Identity
{
    public interface ICurrentIdentitySetter
    {
        void SetIdentity(string email, string nickname, string name, ICollection<string> permissions);

    }
}
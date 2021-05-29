using System.Collections.Generic;

namespace Euro21bet.Application.Common.Interfaces.Identity
{
    public interface ICurrentIdentitySetter
    {
        void SetIdentity(string email, string nickname, string name, ICollection<string> permissions);

    }
}
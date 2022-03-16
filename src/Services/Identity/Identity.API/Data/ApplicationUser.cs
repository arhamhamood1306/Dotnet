using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityAPI.Data
{
    public class ApplicationUser: IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }

    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityAPI.Data
{

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        
        //public string ClaimSelected;
    }
}

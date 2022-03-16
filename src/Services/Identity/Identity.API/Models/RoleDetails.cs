using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPI.Models
{
    public class RoleDetails
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public IList<ClaimDetails> RoleClaims { get; set; }
    }
}

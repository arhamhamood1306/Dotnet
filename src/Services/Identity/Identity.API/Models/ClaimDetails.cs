using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.Models
{
    public class ClaimDetails
    {
        [Required]
        public string ClaimType { get; set; }
        [Required]
        public int ClaimValue { get; set; }
        public bool ClaimSelected { get; set; }
        
    }
}

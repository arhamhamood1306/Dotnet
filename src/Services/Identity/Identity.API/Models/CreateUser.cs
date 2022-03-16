using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.Models
{
    public class CreateUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; init; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; init; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; init; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; init; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; init; }
        [Required]
        [Display(Name = "UserFullName")]
        public string UserFullName { get; init; }

        public IList<RoleDetailsRequestViewModel> RoleDetails { get; set; }
    }
}

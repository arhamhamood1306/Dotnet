using IdentityAPI.Data;
using IdentityAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        // POST api/<AccountController>
        [HttpPost]
        [Authorize]
        [Route("CreateUser")]
        public async Task<IActionResult> AddUser(CreateUser model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return new BadRequestObjectResult(new { Message = "User Creation Failed" });
            }
            var identityUser = new ApplicationUser()
            {
                UserName = model.UserName,
                NormalizedUserName = model.UserFullName,
                Email = model.Email,
                PhoneNumber=model.PhoneNumber,
                PasswordHash=model.Password
            };
            var result = await userManager.CreateAsync(identityUser, model.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Creation Failed", Errors = dictionary });
            }
            /*
            foreach (var role in model.RoleDetails)
            {
                newUser = await userManager.FindByIdAsync(role.RoleId.ToString());
                await userManager.AddToRoleAsync(identityUser, result.ToString());
            }
            */
                return Ok(new { Message = "User Creation Successful" });

        }
    }
}

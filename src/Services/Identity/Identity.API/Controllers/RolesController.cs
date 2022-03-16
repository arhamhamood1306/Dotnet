using IdentityAPI.Data;
using IdentityAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static IdentityAPI.Enum.Actions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;
        public RolesController(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            this.roleManager = roleManager;
            this.dbContext = dbContext;
        }
        // POST api/<RolesController>
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleDetails roledetails)
        {
            if (!ModelState.IsValid || roledetails == null)
            {
                return new BadRequestObjectResult(new { Message = "Role Creation Failed" });
            }

            var result = await roleManager.CreateAsync(new IdentityRole(roledetails.RoleName));
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "Role Creation Failed", Errors = dictionary });
                
            }
            var role = await roleManager.FindByNameAsync(roledetails.RoleName);
            
            foreach (var permission in roledetails.RoleClaims)
            {
                Claim newClaim =new Claim(permission.ClaimType, System.Enum.GetName(typeof(ScreenActions), permission.ClaimValue));
                //newClaim.Properties.Add("ClaimSelected", "1");
                var addClaimResult = await roleManager.AddClaimAsync(role,newClaim);
                
                if (!addClaimResult.Succeeded)
                {
                    return new BadRequestObjectResult(new { Message = "Permissions Not Created" });
                }
            }
            return Ok(new { Message = "Role Creation Successful and Persmissions Created Successful" });
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public JsonResult GetAllRoles()
        {
            return new JsonResult(roleManager.Roles.ToList());
        }
    }
}

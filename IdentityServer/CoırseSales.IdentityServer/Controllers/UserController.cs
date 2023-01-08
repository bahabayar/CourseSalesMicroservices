﻿using CourseSales.IdentityServer.Dtos;
using CourseSales.IdentityServer.Models;
using CourseSales.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace CourseSales.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto model)
        {

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                City = model.City,
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }
            else
            {
                return NoContent();
            }

        }

    }
}

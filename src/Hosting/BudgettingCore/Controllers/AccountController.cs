using Budgetting.Domain.Models;
using Budgetting.Domain.Queries.ApplicationUserQueries;
using BudgettingCore.Core;
using BudgettingCore.Models.UserManagement;
using BudgettingDomain.Commands.ApplicationUserCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<ApplicationUser> logger;
        private readonly IMediator mediator;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(ILogger<ApplicationUser> logger,
                                 IMediator mediator
                                 //UserManager<ApplicationUser> userManager,
                                 //SignInManager<IdentityUser> signInManager
            )
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            // Create a new user object

            // Create the user with the specified password
            var result = await AuthorizationConstants.USER_MANAGER.CreateAsync(user, user?.Password);

            if (result.Succeeded)
            {
                // User created successfully
                return Ok("User created successfully");
            }
            else
            {
                // Failed to create user, return errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
        }


        [HttpPost(Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await AuthorizationConstants.SIGN_IN_MANAGER.PasswordSignInAsync(model?.UserName, model?.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");
                    return Ok(model);
                    //return RedirectToLocal(returnUrl);
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                //}
                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return BadRequest("User account locked out.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest("Invalid login attempt.");
                }
            }
            // If we got this far, something failed, redisplay form
            return Ok(model);
        }

        [HttpPost(Name = "Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await AuthorizationConstants.SIGN_IN_MANAGER.SignOutAsync();
            logger.LogInformation("User logged out.");
            return Ok();
        }

        //[AllowAnonymous]
        //public ActionResult Login()
        //{
        //}

        //public ActionResult Logout()
        //{
        //}

        [HttpGet(Name = "GetUsers")]
            public async Task<IActionResult> GetAllUsers()
            {
                try
                {
                    var query = new GetAllApplicationUsersQuery();
                    var users = mediator.Send(query);

                    return Ok(users);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }

        
        }
}

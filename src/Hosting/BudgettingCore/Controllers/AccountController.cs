﻿using Budgetting.Api.Helpers.Implementations;
using Budgetting.Api.Helpers.Interfaces;
using Budgetting.Domain.Models;
using Budgetting.Domain.Models.Core;
using Budgetting.Domain.Queries.ApplicationUserQueries;
using BudgettingCore.Core;
using BudgettingCore.Extensions;
using BudgettingCore.Models;
using BudgettingCore.Models.UserManagement;
using BudgettingDomain.Commands.ApplicationUserCommands;
using ExpressMapper.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BudgettingCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class AccountController : ApiControllerBase
    {
        private readonly ILogger<ApplicationUser> logger;
        private readonly IMediator mediator;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILoginClient loginClient;
        private readonly ITokenService _tokenService;

        public AccountController(ILogger<ApplicationUser> logger,
                                 IMediator mediator,
                                 UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ILoginClient loginClient,
                                 ITokenService tokenService

            )
        {
            this.mediator = mediator;
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.loginClient = loginClient;
            this._tokenService = tokenService;

        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var claim = await userManager.FindByEmailFromClaimsPrincipal(HttpContext.User);
            if(claim == null)
            {
                return NotFound();
            }
            var user = new LoginModel
            {
                UserName = claim.UserName,
                Token = _tokenService.CreateToken(claim)
            };
            return Ok(user);
        }

        // TODO: implementation of role management
        [HttpPost(Name = "Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var msg = "invalid model state";
            // Create a new user object
            
            // Create the user with the specified password
            user.EmailConfirmed = true;
            var result = await userManager.CreateAsync(user, user?.Password);

            if (result.Succeeded)
            {

                var createdUser = await userManager.FindByNameAsync(user?.UserName);
                if (createdUser != null)
                {
                    await userManager.AddToRoleAsync(createdUser, IdentityRoles.User.ToString());
                }
                // User created successfully
                msg = "User created successfully";
                var u = createdUser?.Map<ApplicationUser, LoginModel>();
                u.Token = _tokenService.CreateToken(createdUser);
                return Ok(u);
            }
            else
            {
                // Failed to create user, return errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                msg = "Failed to create user";
                return Ok(GetServerResult(msg, result.Succeeded, result.Errors));
            }

        }


        [HttpPost(Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]  LoginModel model)
        {
            var msg = "";
            var user = await userManager.FindByNameAsync(model?.UserName);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await signInManager.PasswordSignInAsync(model?.UserName, model?.Password, model.RememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                msg = "User logged in.";
                logger.LogInformation(msg);
                var token = _tokenService.CreateToken(user);
                model.Token = token;

                return Ok(model);
                //return RedirectToLocal(returnUrl);
            }
            //if (result.RequiresTwoFactor)
            //{
            //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
            //}
            if (result.IsLockedOut)
            {
                msg = "User account locked out.";
                logger.LogWarning(msg);
                return Ok(GetServerResult(msg, result.Succeeded));
            }
            else
            {
                msg = "Invalid login attempt.";
                ModelState.AddModelError(string.Empty, msg);
                return Ok(GetServerResult(msg, result.Succeeded, result));
            }
            // If we got this far, something failed, redisplay form
            return Ok(GetServerResult(msg, false));
        }

        [HttpPost(Name = "Logout")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {

                await this.signInManager.SignOutAsync();
                var msg = "User logged out.";
                logger.LogInformation(msg);
                return Ok(GetServerResult(msg, true));
            }
            catch(Exception ex)
            {
                var msg = "User logged out failed.";
                logger.LogWarning(msg);
                return BadRequest(GetServerResult(msg, false, ex));
            }
        }

        [HttpGet(Name = "GetUsers")]
            public async Task<IActionResult> GetAllUsers()
            {
                try
                {

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
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

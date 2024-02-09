using Budgetting.Api.Helpers.Interfaces;
using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Api.Helpers.Implementations
{
    public class LoginClient :  ILoginClient
    {
        private UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public LoginClient(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // TODO: implement null guard
        public async Task<string> GenerateUserToken(string userName, string tokentProvider, string purpose)
        {
            try
            {
                var user = await userManager.FindByNameAsync(userName);
                var roles = await userManager.GetRolesAsync(user);
                var role = string.Join(";", roles);
                user.UserRoles = role;
                var token = await userManager.GenerateUserTokenAsync(user, "Default", string.Empty);

                return token;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

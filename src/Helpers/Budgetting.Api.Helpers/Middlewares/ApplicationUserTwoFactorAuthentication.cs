using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Api.Helpers.Middlewares
{
    public class ApplicationUserTwoFactorAuthentication<TUser> : IUserTwoFactorTokenProvider<TUser> where TUser : ApplicationUser
    {
        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            if (manager != null && user != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        // Genereates a simple token based on the user id, email and another string.
        private string GenerateTokenAsync(ApplicationUser user, string purpose)
        {
            //string secretString = "greatNews";
            //return secretString + user.Email + purpose + user.Id;
            var claims = JsonConvert.SerializeObject( user.GetUserClaims().Select(b => new
            {
                Name = b.Type,
                b.Value
            }));

            return claims ?? string.Empty;
        }

        public Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult( GenerateTokenAsync(user, purpose));
        }

        public Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(token == GenerateTokenAsync(user, purpose));
        }
    }
}

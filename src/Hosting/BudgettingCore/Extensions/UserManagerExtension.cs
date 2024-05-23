using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BudgettingCore.Extensions
{
    public static class UserManagerExtension
    {
        public static async Task<ApplicationUser> FindByEmailFromClaimsPrincipal(this UserManager<ApplicationUser> input, ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Email)?.Value;
            return input.Users.SingleOrDefault(f => f.Email == email);
        }
    }
}

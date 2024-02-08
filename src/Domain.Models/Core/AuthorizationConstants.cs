using Budgetting.Domain.Models;
using Budgetting.Domain.Models.Core;
using Microsoft.AspNetCore.Identity;

namespace BudgettingCore.Core
{
    public static class AuthorizationConstants
    {
        /// <summary>
        /// Don't use in production
        /// </summary>
        public static string DEFAULT_PASSWORD => "Passw0rd@123!";
        public static string WEB_APP_ENDPOINT => "http://localhost:4200/";
        public static string API_ENDPOINT => "https://localhost:6001";
        public static List<IdentityRole> IDENTITY_ROLES => new List<IdentityRole> {
            new IdentityRole
            {
                Id = "01",
                Name = IdentityRoles.Administrator.ToString()
            },
            new IdentityRole
            {
                Id = "02",
                Name = IdentityRoles.User.ToString()
            }
        };
       
    }
}

using Budgetting.Domain.Models;
using Budgetting.Domain.Models.Core;
using BudgettingCore.Core;
using BudgettingPersistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Persistence
{
    public class IdentityContextSeed
    {
        public static async Task SeedAsync(IdentityContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (identityDbContext.Database.IsSqlite())
            {
                identityDbContext.Database.Migrate();
            }

            var role = new IdentityRole
            {
                Id = "01",
                Name = IdentityRoles.Administrator.ToString()
            };


            await roleManager.CreateAsync(role);

            var defaultUser = new ApplicationUser { UserName = "admin", Email = "akumbommarietta@gmail.com" };
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

            string adminUserName = "admin@microsoft.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByNameAsync(adminUserName);

            if(adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, IdentityRoles.Administrator.ToString());
            }
        }
    }
}

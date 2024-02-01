using Budgetting.Domain.Models;
using BudgettingPersistence;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class ApplicationUserService : ServiceBase<ApplicationUser>, IApplicationUserService
    {
        public ApplicationUserService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<ApplicationUser> AddOrUpdateItem(ApplicationUser item)
        {
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }

            return await base.AddOrUpdateItem(item);
        }

        public override async Task<ApplicationUser> GetItem(ApplicationUser item)
        {
            return await Context.ApplicationUsers.FindAsync(item.EntityKeys);
        }
    }
}

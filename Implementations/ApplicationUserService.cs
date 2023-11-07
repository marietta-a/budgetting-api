using BudgettingDomain.Entities;
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
    }
}

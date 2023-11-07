using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingPersistence
{
    public interface IIdentityContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}

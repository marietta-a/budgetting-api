using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T existing) where T : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
    }
}

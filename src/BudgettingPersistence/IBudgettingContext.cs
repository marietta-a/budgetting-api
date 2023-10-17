using BudgettingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingPersistence
{
    public interface IBudgettingContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        DatabaseFacade Database { get; }
        DbSet<FinancialOperation> FinancialOperations { get; set; }
        DbSet<FinancialOperationType> FinancialOperationTypes { get; set; }
        DbSet<Staff> Staff { get; set; }
        Task<int> SaveChangesAsync();
    }
}

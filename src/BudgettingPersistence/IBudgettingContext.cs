using BudgettingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingPersistence
{
    public interface IBudgettingContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TransactionType> TransactionTypes { get; set; }
        DbSet<Staff> Staff { get; set; }
        Task<int> SaveChangesAsync();
    }
}

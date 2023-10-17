using BudgettingDomain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingPersistence
{
    public class BudgettingContext : DbContext, IBudgettingContext
    {
        
        public BudgettingContext()
        {
        }
        public BudgettingContext(DbContextOptions<BudgettingContext> options) : base(options)
        {
        }
        public static string ConnectionString { get; set; }

        public DbSet<FinancialOperation> FinancialOperations { get; set; }
        public DbSet<FinancialOperationType> FinancialOperationTypes { get; set; }
        public DbSet<Staff> Staff { get;set ; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            if (!optionsBuilder.IsConfigured)
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder(ConnectionString)
                {
                    DataSource = $"{path}\\Budgetting.db"
                };
                var connectionString = connectionStringBuilder.ToString();
                var connection = new SqliteConnection(connectionString);

                optionsBuilder.UseSqlite(connection);
            }
        }
    }
}

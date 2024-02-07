using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingPersistence
{
    public class IdentityContext : DbContext, IIdentityContext
    {
        public IdentityContext()
        {
        }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        public static string ConnectionString { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("User").HasKey(b => b.Id);
            builder.Entity<IdentityRole>().ToTable("Role").HasKey(b => b.Id);
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole").HasKey(b => new { b.RoleId, b.UserId });
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim").HasKey(b => b.Id);
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin").HasKey(b => b.UserId);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim").HasKey(b => b.Id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            if (!optionsBuilder.IsConfigured)
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder(ConnectionString)
                {
                    //DataSource = $"{path}\\Identity.db"
                };
                var connectionString = connectionStringBuilder.ToString();
                var connection = new SqliteConnection(connectionString);

                optionsBuilder.UseSqlite(connection);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

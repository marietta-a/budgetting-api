using Budgetting.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        EntityEntry<T> Entry<T>(T existing) where T : class;
        DatabaseFacade Database { get; }
        DbSet<FinancialOperation> FinancialOperations { get; set; }
        DbSet<FinancialOperationType> FinancialOperationTypes { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Shipment> Shipments { get; set; }
        DbSet<WishList> WishLists { get; set; }

        Task<int> SaveChangesAsync();
    }
}

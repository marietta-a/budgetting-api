using BudgettingPersistence;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Implementations
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        public IBudgettingContext Context { get; set; }
        public ServiceBase(IBudgettingContext _ctx) 
        { 
            Context = _ctx;
        }

        public async Task<T> GetItem(T item)
        {
            try
            {
                return await Context.Set<T>().FindAsync(item);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }

        public async Task<T> AddOrUpdateItem(T item)
        {
            using (var trans = Context.Database.BeginTransaction())
            {
                try
                {
                    var existing = GetItem(item);
                    if (existing != null)
                    {
                        Context.Set<T>().Update(item);
                    }
                    else
                    {
                       await Context.Set<T>().AddAsync(item);
                    }
                    await Context.SaveChangesAsync();
                    return item;
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public async Task<IQueryable<T>> GetItems()
        {
            try
            {
                return Context.Set<T>();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }
    }
}

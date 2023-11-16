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
        protected IBudgettingContext Context { get; set; }
        public ServiceBase(IBudgettingContext _ctx) 
        { 
            Context = _ctx;
        }

        public abstract Task<T> GetItem(T item);

        public virtual async Task<T> AddOrUpdateItem(T item)
        {
            using (var trans = Context.Database.BeginTransaction())
            {
                try
                {
                    var existing = await GetItem(item);
                    if (existing != null)
                    {
                        Context.Set<T>().Update(item);
                    }
                    else
                    {
                       await Context.Set<T>().AddAsync(item);
                    }
                    await Context.SaveChangesAsync();
                    await trans.CommitAsync();
                    return item;
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public virtual async Task<IQueryable<T>> GetItems()
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

        public Task<T> DeleteItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}

using BudgettingPersistence;
using Microsoft.EntityFrameworkCore;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Implementations
{
    public abstract class IdentityServiceBase<T> : IServiceBase<T> where T : class
    {
        protected IIdentityContext Context { get; set; }
        public IdentityServiceBase(IIdentityContext _ctx)
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
                        Context.Entry(existing).State = EntityState.Detached;
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
                catch (Exception ex)
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

        public async Task<T> DeleteItem(T item)
        {
            try
            {
                using (var trans = Context.Database.BeginTransaction())
                {
                    var existing = await GetItem(item);
                    if (existing != null)
                    {
                        Context.Set<T>().Remove(existing);
                        await Context.SaveChangesAsync();
                        await trans.CommitAsync();
                    }
                    return existing;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

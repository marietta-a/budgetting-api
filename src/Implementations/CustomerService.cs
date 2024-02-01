using Budgetting.Domain.Models;
using Budgetting.Services;
using BudgettingPersistence;
using Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Repository
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        public CustomerService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Customer> GetItem(Customer item)
        {
            return await Context.Customers.FindAsync(item.EntityKeys);
        }
    }
}

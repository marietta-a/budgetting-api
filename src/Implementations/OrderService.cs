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
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        public OrderService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Order> GetItem(Order item)
        {
            return await Context.Orders.FindAsync(item.EntityKeys);
        }
    }
}

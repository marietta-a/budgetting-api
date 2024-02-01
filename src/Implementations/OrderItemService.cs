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
    public class OrderItemService : ServiceBase<OrderItem>, IOrderItemService
    {
        public OrderItemService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<OrderItem> GetItem(OrderItem item)
        {
            return await Context.OrderItems.FindAsync(item.EntityKeys);
        }
    }
}

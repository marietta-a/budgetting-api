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
    public class CartService : ServiceBase<Cart>, ICartService
    {
        public CartService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Cart> GetItem(Cart item)
        {
            return await Context.Carts.FindAsync(item.EntityKeys);
        }
    }
}

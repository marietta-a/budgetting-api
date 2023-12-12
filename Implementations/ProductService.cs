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
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Product> GetItem(Product item)
        {
            return await Context.Products.FindAsync(item.EntityKeys);
        }
    }
}

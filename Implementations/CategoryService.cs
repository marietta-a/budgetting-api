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
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        public CategoryService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<Category> GetItem(Category item)
        {
            return await Context.Categories.FindAsync(item.EntityKeys);
        }
    }
}

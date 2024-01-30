using Budgetting.Domain.Models;
using Budgetting.Domain.Models.Common;
using Budgetting.Domain.Models.Core;
using Budgetting.Services;
using BudgettingPersistence;
using FluentValidation.Resources;
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

        public override Task<Category> AddOrUpdateItem(Category item)
        {
            if (string.IsNullOrEmpty(item?.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            return base.AddOrUpdateItem(item);
        }
        public override async Task<Category> GetItem(Category item)
        {
            return await Context.Categories.FindAsync(item.EntityKeys);
        }

        public async Task<List<LookupTableData>> GetParentCategories()
        {
            return LookupItems.ParentCategoryTypes.Where(b => b.LanguageCode == Languages.English.ToT2D()).ToList();
        }
    }
}

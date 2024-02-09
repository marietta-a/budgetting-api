using Budgetting.Domain.Models;
using Budgetting.Domain.Models.Common;
using Budgetting.Domain.Models.Core;
using Budgetting.Services;
using BudgettingPersistence;
using Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            item.Slug = Regex.Replace(item?.Name, @"\s", "-");
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


        public async Task<List<ParentCategories>> GetDetailedCategories()
        {
            try
            {
                var categories = await (await this.GetItems()).ToListAsync();
                var pCategories = await this.GetParentCategories();

                var query = pCategories.GroupJoin(categories, p => p.DataCode, c => c.ParentCategoryId, (p, c) => new
                {
                    Parent = p,
                    Categories = c.ToArray()
                }).Where(b => b.Categories != null).Select(b => new ParentCategories
                {
                    Parent = b?.Parent,
                    Categories = b?.Categories,
                })?.ToList();

                return query;

            }
            catch(Exception ex)
            {
                throw;
            }
         }
    }
}

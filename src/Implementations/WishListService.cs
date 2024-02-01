﻿using Budgetting.Domain.Models;
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
    public class WishListService : ServiceBase<WishList>, IWishListService
    {
        public WishListService(IBudgettingContext _ctx) : base(_ctx)
        {
        }

        public override async Task<WishList> GetItem(WishList item)
        {
            return await Context.WishLists.FindAsync(item.EntityKeys);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models.Core
{
    public enum LookupTableName
    {
        Languages = 1,
        ProductStatuses,
        ProductSizes,
        ParentCategoryTypes,
    }

    public enum Languages
    {
        English = 1,
        French
    }

    public enum ProductStatuses
    {
        New = 1,
        OutOfStock
    }
    
    public enum ProductSizes
    {
        XXS = 1,
        XS,
        S,
        M,
        ML,
        L,
        XL,
        XXL
    }

    public enum ParentCategoryTypes
    {
        Cosmetics = 1,
        Accessories
    }
}

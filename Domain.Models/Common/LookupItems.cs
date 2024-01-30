using Budgetting.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models.Common
{
    public sealed class LookupItems
    {
        public static List<LookupTableData> ParentCategoryTypes => new List<LookupTableData>
        {
            new LookupTableData
            {
                TableId = LookupTableName.ParentCategoryTypes.ToT2D(),
                DataCode = "01",
                LanguageCode = Languages.English.ToT2D(),
                DataText = "Cosmetics",
            },
            new LookupTableData
            {
                TableId = LookupTableName.ParentCategoryTypes.ToT2D(),
                DataCode = "01",
                LanguageCode = Languages.French.ToT2D(),
                DataText = "Cosmétique",
            },
            new LookupTableData
            {
                TableId = LookupTableName.ParentCategoryTypes.ToT2D(),
                DataCode = "02",
                LanguageCode = Languages.English.ToT2D(),
                DataText = "Accessories",
            },
            new LookupTableData
            {
                TableId = LookupTableName.ParentCategoryTypes.ToT2D(),
                DataCode = "02",
                LanguageCode = Languages.French.ToT2D(),
                DataText = "Accessoires",
            }
        };

        public static List<LookupTableData> ProductStatuses => new List<LookupTableData>
        {
            new LookupTableData
            {
                TableId = LookupTableName.ProductStatuses.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "01",
                DataText = "New",
            },
            new LookupTableData
            {
                TableId = LookupTableName.ProductStatuses.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "01",
                DataText = "Nouvelle",
            },
            new LookupTableData
            {
                TableId = LookupTableName.ProductStatuses.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "02",
                DataText = "Out of stock",
            },
            new LookupTableData
            {
                TableId = LookupTableName.ProductStatuses.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "02",
                DataText = "Rupture de stock",
            }
        };

        public static List<LookupTableData> ProductSizes => new List<LookupTableData>
        {
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "01",
                DataText = "XXS",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "01",
                DataText = "XXS",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "02",
                DataText = "XS",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "02",
                DataText = "XS",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "03",
                DataText = "S",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "03",
                DataText = "S",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "04",
                DataText = "M",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "04",
                DataText = "M",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "05",
                DataText = "ML",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "05",
                DataText = "ML",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "06",
                DataText = "L",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "06",
                DataText = "L",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "07",
                DataText = "XL",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "07",
                DataText = "XL",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.English.ToT2D(),
                DataCode = "08",
                DataText = "XXL",
            },
            new LookupTableData 
            {
                TableId = LookupTableName.ProductSizes.ToT2D(),
                LanguageCode = Languages.French.ToT2D(),
                DataCode = "08",
                DataText = "XXL",
            },
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class ParentCategories
    {
        public LookupTableData Parent { get; set; }
        public Category[] Categories { get; set; }
        public string Id => Parent?.Id;
    }
}

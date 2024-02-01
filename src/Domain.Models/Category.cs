using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Category
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(75)]
        public string Slug { get; set; }
        [StringLength(10)]
        public string? ParentCategoryId { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };
        [NotMapped]
        public LookupTableData ParentCategory { get; set; }
    }
}

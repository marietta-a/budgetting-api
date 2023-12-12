using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Product
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string SKU { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [StringLength(50)]
        public string CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };

    }
}

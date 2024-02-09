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
        [StringLength(75)]
        public string Slug { get; set; }
        [StringLength(25)]
        public string? ColorCode { get; set; }
        [StringLength(25)]
        public string? ShortName { get; set; }
        [StringLength(100)]
        public string? SKU { get; set; }
        [StringLength(150)]
        public string? Description { get; set; }
        [StringLength(50)]
        public string CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(25)]
        public string? CreatedBy { get; set; }
        [StringLength(25)]
        public string? DeliveryTimeSpan { get; set; }
        [StringLength(500)]
        public string ImageUrl { get; set; }
        [StringLength(10)]
        public string? StatusCode { get; set; }
        [StringLength(10)]
        public string? PromotionCode { get; set; }
        [StringLength(250)]
        public string? Brand { get; set; }
        [StringLength(5)]
        public string? Size { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };

    }
}

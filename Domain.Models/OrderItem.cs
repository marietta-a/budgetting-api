using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class OrderItem
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string OrderId { get; set; }
        [StringLength(50)]
        public string ProductId { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
    }
}

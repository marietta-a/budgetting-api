using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Order
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get;set; }
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(50)]
        public string ShipmentId { get; set; }
        [StringLength(50)]
        public string PaymentId { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };
    }
}

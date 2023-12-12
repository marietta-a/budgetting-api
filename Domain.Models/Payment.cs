using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Payment
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public DateTime PaymentDate { get; set; }
        [StringLength(50)]
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        [StringLength(50)]
        public string CustomerId { get; set; }
    }
}

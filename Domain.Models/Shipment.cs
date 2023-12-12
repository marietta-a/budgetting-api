using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Shipment
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength (50)]
        public string State { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string PostalCode { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };
    }
}

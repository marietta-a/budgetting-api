using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class WishList
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(50)]
        public string ProductId { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };

    }
}

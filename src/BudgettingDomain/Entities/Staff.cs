using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Entities
{
    public class Staff
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Telephone { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Entities
{
    public class Transaction : BaseEntity
    {
        [StringLength(4)]
        [Required]
        public string TransactionTypeId { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}

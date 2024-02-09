using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }

    }
}

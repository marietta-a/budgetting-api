using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Category
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}

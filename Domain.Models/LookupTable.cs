using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class LookupTable
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        public string TableName { get; set; }
    }
}

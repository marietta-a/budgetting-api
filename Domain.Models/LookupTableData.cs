using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class LookupTableData
    {
        [Key]
        public string TableId { get; set; }
        [Key]
        [StringLength(10)]
        public string DataCode { get; set; }
        [Key]
        [StringLength(10)]
        public string LanguageCode { get; set; }
        [StringLength(10)]
        public string Abr { get; set; }
        [StringLength(100)]
        public string DataText { get; set; }
        [NotMapped]
        public string Id => $"{TableId}{DataCode}{LanguageCode}";
    }
}

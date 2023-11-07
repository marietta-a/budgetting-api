using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class FinancialOperationType : BaseEntity
    {
        [StringLength(25)]
        public string Type { get; set; }
        public int Operation { get; set; }

    }
}

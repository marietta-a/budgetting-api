using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class Customer
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        [StringLength(250)]
        [Required] 
        public string FirstName { get; set; }
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }
        [StringLength(250)]
        [Required]
        public string Email { get; set; }
        [StringLength (250)]
        public string Address { get;set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string PasswordHash { get; set; }
    }
}

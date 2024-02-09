using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? CreatedDate { get; set; }
        [NotMapped]
        public string[] EntityKeys => new[] { Id };
        [NotMapped]
        public string UserRoles { get; set; }


        public List<Claim> GetUserClaims()
        {
            //var roles = userManger.GetRolesAsync(this).Result;
            //var role = JsonConvert.SerializeObject(roles);
            return new List<Claim>()
            {
                new Claim("FistName", FirstName),
                new Claim("LastName", LastName),
                new Claim("Email", Email ?? string.Empty),
                new Claim("UserName", UserName ?? string.Empty),
                new Claim("Role", UserRoles)
            };
        }
    }
}

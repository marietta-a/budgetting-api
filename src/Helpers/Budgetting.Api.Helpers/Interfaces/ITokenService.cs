using Budgetting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Api.Helpers.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user);
    }
}

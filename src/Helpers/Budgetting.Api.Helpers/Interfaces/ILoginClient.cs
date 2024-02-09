using Budgetting.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Api.Helpers.Interfaces
{
    public interface ILoginClient 
    {
        Task<string> GenerateUserToken(string userName, string tokentProvider = "Default", string purpose = "");
     }
}

using BudgettingDomain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BudgettingCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IdentityController : ControllerBase
    {
        private ILogger<IdentityController> _logger;

        public IdentityController(ILogger<IdentityController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserClaim")]
        public ApplicationUser Get()
        {
            var transaction = new ApplicationUser
            {
                LastName = "A",
                FirstName = "Doe",
            };
            return transaction;
            //return new JsonResult(from c in User.Claims select  new {c.Type, c.Value});
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BudgettingCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private ILogger<IdentityController> _logger;

        public IdentityController(ILogger<IdentityController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = new JsonResult(from c in User.Claims select new { c.Type, c.Value });
            return result;
        }
    }
}
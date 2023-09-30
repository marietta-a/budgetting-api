using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "login", Order = 1)]
        public ActionResult Login()
        {
            return Redirect("http://localhost:4200/#/login");
        }
        [HttpGet(Name = "register", Order = 2)]
        public ActionResult Register()
        {
            return Redirect("http://localhost:4200/#/register");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StaffController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        //private IStaffService<Staff> _staffService;

        public StaffController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        //[HttpPost]
        //public ActionResult AddStaff(string id)
        //{

        //}
    }
}

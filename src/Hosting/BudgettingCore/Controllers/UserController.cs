using Budgetting.Domain.Models;
using Budgetting.Domain.Queries.ApplicationUserQueries;
using BudgettingDomain.Commands.ApplicationUserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgettingCore.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<ApplicationUser> logger;
        private readonly IMediator mediator;

        public UserController(ILogger<ApplicationUser> logger, IMediator mediator)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> CreateUser(CreateApplicationUserCommand command)
        {
            var record = mediator.Send(command);
            return Ok(record);
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetALlUsers()
        {
            var query = new GetAllApplicationUsersQuery();
            var users = mediator.Send(query);

            return Ok(users);
        }

        
    }
}

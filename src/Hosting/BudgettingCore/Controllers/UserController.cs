﻿using Budgetting.Domain.Models;
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
        public async Task<IActionResult> CreateUser([FromBody] CreateApplicationUserCommand command)
        {
            try
            {
                var record = mediator.Send(command);
                return Ok(record);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetALlUsers()
        {
            try
            {
                var query = new GetAllApplicationUsersQuery();
                var users = mediator.Send(query);

                return Ok(users);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        
    }
}

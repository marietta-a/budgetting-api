﻿using Budgetting.Domain.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgettingDomain.Commands.ApplicationUserCommands
{
    public class ApplicationUserCommandHandler : ICommandHandler<CreateApplicationUser>
    {
        private IApplicationUserService service;
        public ApplicationUserCommandHandler(IApplicationUserService service)
        {
            this.service = service;
        }

        public async ValueTask Handle(CreateApplicationUser command, CancellationToken cancellationToken)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = command.UserName,
                    Email = command.Email,

                };

               await service.AddOrUpdateItem(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

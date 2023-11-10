using Budgetting.Domain.Models;
using ExpressMapper.Extensions;
using MediatR;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BudgettingDomain.Commands.ApplicationUserCommands
{
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, ApplicationUser>
    {
        private IApplicationUserService service;
        public CreateApplicationUserCommandHandler(IApplicationUserService service)
        {
            this.service = service;
        }

        async Task<ApplicationUser> IRequestHandler<CreateApplicationUserCommand, ApplicationUser>.Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = request.UserName,
                    Email = request.Email,

                };

                var result = await service.AddOrUpdateItem(user);

                return result;
            }
            catch (Exception ex)
            { 
                throw;
            }
        }
    }
}

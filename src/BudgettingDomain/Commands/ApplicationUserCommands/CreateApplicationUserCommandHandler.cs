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

        public async ValueTask Handle(CreateApplicationUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = command.Map<CreateApplicationUserCommand, ApplicationUser>();

                await service.AddOrUpdateItem(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ApplicationUser> IRequestHandler<CreateApplicationUserCommand, ApplicationUser>.Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = request.Map<CreateApplicationUserCommand, ApplicationUser>();

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

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

        public ValueTask Handle(CreateApplicationUser command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

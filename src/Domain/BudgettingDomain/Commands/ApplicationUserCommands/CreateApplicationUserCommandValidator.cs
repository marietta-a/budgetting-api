using BudgettingDomain.Commands.ApplicationUserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetting.Domain.Commands.ApplicationUserCommands
{
    public class CreateApplicationUserCommandValidator: AbstractValidator<CreateApplicationUserCommand>
    {
        public CreateApplicationUserCommandValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}

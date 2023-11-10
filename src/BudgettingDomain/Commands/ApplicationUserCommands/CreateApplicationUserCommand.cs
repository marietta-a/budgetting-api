using Budgetting.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgettingDomain.Commands.ApplicationUserCommands
{
    public class CreateApplicationUserCommand: IRequest<ApplicationUser>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public CreateApplicationUserCommand(string UserName, string Email)
        { 
            this.Email = Email;
            this.UserName = UserName;
        }

        public CreateApplicationUserCommand()
        {
        }
    }
}

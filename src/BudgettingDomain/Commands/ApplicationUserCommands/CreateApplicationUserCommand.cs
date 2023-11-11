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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateApplicationUserCommand()
        {
        }

        public CreateApplicationUserCommand(string userName, string email, string firstName, string lastName)
        {
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}

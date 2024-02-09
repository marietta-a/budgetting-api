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
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public CreateApplicationUserCommand()
        {
        }

        public CreateApplicationUserCommand(string id, string userName, string email, string firstName, string lastName, string password, string address, string phoneNumber)
        {
            Id = id;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}

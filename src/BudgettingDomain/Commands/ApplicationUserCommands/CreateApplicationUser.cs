using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgettingDomain.Commands.ApplicationUserCommands
{
    public class CreateApplicationUser 
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public CreateApplicationUser(string UserName, string Email)
        { 
            this.Email = Email;
            this.UserName = UserName;
        }
    }
}

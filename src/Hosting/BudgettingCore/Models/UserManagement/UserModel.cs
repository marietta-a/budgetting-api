using Budgetting.Domain.Models;

namespace BudgettingCore.Models.UserManagement
{
    public class UserModel: ApplicationUser
    {
        public string Password { get; set; }
        public string Token { get; set; }
    }
}

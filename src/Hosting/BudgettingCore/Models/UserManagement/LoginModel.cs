namespace BudgettingCore.Models.UserManagement
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string? returnUrl { get; set; }
        public string? Token { get; set; }
    }
}

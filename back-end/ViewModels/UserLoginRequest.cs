using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UserLoginRequest
    {
        [Required]
        private string email;
        [Required]
        private string password;
        [Required]
        private string rememberMe;

        public UserLoginRequest()
        {
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string RememberMe { get => rememberMe; set => rememberMe = value; }
    }
}

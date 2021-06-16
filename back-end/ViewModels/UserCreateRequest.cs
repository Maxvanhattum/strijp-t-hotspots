using System.ComponentModel.DataAnnotations;
using ViewModels.Enums;

namespace ViewModels
{
    public class UserCreateRequest
    {
        [Required]
        private string email;
        [Required]
        private string password;
        [Required]
        private string firstname;
        [Required]
        private string lastname;
        private Role role;

        public UserCreateRequest()
        {
        }

        public UserCreateRequest(string email, string password, string firstname, string lastname, Role role)
        {
            this.email = email;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = role;
        }

        public string Email { get => email; set => email = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public Role Role { get => role; set => role = value; }
        public string Password { get => password; set => password = value; }
    }
}

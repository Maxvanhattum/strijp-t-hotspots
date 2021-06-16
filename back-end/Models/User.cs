using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        private int id;
        [EmailAddress]
        private string email;
        private string password;
        private string firstname;
        private string lastname;
        private string role;

        public User()
        {
        }

        public User(string email, string password, string firstname, string lastname, string role)
        {
            this.email = email;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = role;
        }

        public User(string email, string password, string firstname, string lastname, string role, int id)
        {
            this.email = email;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.role = role;
            this.id = id;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Role { get => role; set => role = value; }
        public int Id { get => id; set => id = value; }
    }
}

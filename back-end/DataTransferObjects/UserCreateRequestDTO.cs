using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class UserCreateRequestDTO
    {

        public UserCreateRequestDTO(string email, string password, string firstname, string lastname, string role)
        {
            Email = email;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
            Role = role;
        }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Password { get; }
        [Required]
        public string Role { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class UserLoginRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string RememberMe { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class BusinessVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public AddressVM Address { get; set; }

    }
}

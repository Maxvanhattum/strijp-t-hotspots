using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class AddressVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string HouseNumber { get; set; }
    }
}

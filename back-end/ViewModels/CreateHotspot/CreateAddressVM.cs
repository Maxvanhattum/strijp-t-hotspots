using System.ComponentModel.DataAnnotations;

namespace ViewModels.CreateHotspot
{
    public class CreateAddressVM
    {
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

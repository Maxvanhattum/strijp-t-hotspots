using System.ComponentModel.DataAnnotations;

namespace ViewModels.CreateHotspot
{
    public class CreateBusinessVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public CreateAddressVM Address { get; set; }
    }
}

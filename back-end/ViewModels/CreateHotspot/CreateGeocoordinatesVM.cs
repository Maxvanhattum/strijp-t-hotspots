using System.ComponentModel.DataAnnotations;

namespace ViewModels.CreateHotspot
{
    public class CreateGeocoordinatesVM
    {
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class GeocoordinatesVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}

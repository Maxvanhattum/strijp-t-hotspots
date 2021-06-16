using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.CreateHotspot
{
    public class CreateHotspotVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public CreateGeocoordinatesVM Geocoordinates { get; set; }

        [Required]
        public CreateInterviewVM Interview { get; set; }

        [Required]
        public CreateAR360VM AR360 { get; set; }

        public List<CreateBusinessVM> Businesses { get; set; }
    }
}

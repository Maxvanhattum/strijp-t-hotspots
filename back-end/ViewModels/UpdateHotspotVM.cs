using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UpdateHotspotVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public GeocoordinatesVM Geocoordinates { get; set; }

        [Required]
        public InterviewVM Interview { get; set; }

        [Required]
        public AR360VM AR360 { get; set; }

        public List<BusinessVM> Businesses { get; set; }
    }
}

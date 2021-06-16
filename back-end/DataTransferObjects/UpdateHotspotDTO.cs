using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class UpdateHotspotDTO
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
        public GeocoordinatesDTO Geocoordinates { get; set; }

        [Required]
        public InterviewDTO Interview { get; set; }

        [Required]
        public AR360DTO AR360 { get; set; }

        public List<BusinessDTO> Businesses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Hotspot
    {
        public Hotspot()
        {
        }
        public Hotspot(int id, string title, string description, DateTime publishDate, int geoCoordinatesId, GeoCoordinates geoCoordinates, int interviewDetailsId, MovieInterviewDetails interviewDetails, int aR360Id, AR360 aR360)
        {
            Id = id;
            Title = title;
            Description = description;
            PublishDate = publishDate;
            GeoCoordinatesId = geoCoordinatesId;
            GeoCoordinates = geoCoordinates;
            InterviewId = interviewDetailsId;
            Interview = interviewDetails;
            AR360Id = aR360Id;
            AR360 = aR360;
        }

        public Hotspot(string title, string description, DateTime publishDate, GeoCoordinates geoCoordinates, MovieInterviewDetails interviewDetails, AR360 aR360)
        {
            Title = title;
            Description = description;
            PublishDate = publishDate;
            GeoCoordinates = geoCoordinates;
            Interview = interviewDetails;
            AR360 = aR360;
        }



        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public int GeoCoordinatesId { get; set; }
        public GeoCoordinates GeoCoordinates { get; set; }

        public int InterviewId { get; set; }
        public MovieInterviewDetails Interview { get; set; }

        public int AR360Id { get; set; }
        public AR360 AR360 { get; set; }

        public List<Business> Businesses { get; set; }
    }
}

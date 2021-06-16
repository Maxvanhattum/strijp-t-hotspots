namespace Models
{
    public class GeoCoordinates
    {
        public GeoCoordinates()
        {
        }

        public GeoCoordinates(string longitude, string latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public GeoCoordinates(int id, string longitude, string latitude)
        {
            Id = id;
            Longitude = longitude;
            Latitude = latitude;
        }

        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }

        public Address(int id, string city, string zipcode, string streetName, string houseNumber)
        {
            Id = id;
            City = city;
            Zipcode = zipcode;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(string city, string zipcode, string streetName, string houseNumber)
        {
            City = city;
            Zipcode = zipcode;
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address()
        {
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Business
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        [Url]
        public string Url { get; set; }


        public Business(string name, Address address, string url)
        {
            Name = name;
            Address = address;
            Url = url;
        }

        public Business(int id, string name, Address address, string url)
        {
            Id = id;
            Name = name;
            Address = address;
            Url = url;
        }

        public Business()
        {
        }
    }
}

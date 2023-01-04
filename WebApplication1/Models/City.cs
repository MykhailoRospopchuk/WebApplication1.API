namespace WebApplication1.Models
{
    public class City
    {
        public Guid CityId { get; set; }
        public string Name { get; set; } = null!;

        public Guid CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public ICollection<University>? Universities { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}

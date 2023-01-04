namespace WebApplication1.Models
{
    public class Country
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; } = null!;

        public Guid RegionId { get; set; }
        public Region Region { get; set; } = null!;

        public ICollection<City>? Cities { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}

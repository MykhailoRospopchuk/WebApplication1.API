namespace WebApplication1.Models
{
    public class Region
    {
        public Guid RegionId { get; set; }
        public string RegionName { get; set; } = null!;

        public ICollection<Country>? Countries { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}

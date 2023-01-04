namespace WebApplication1.Models
{
    public class University
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; } = null!;

        public Guid CityId { get; set; }
        public City City { get; set; } = null!;

        public ICollection<LocalGroup>? LocalGroups { get; set; }
        public ICollection<Person>? Persons { get; set; }

    }
}

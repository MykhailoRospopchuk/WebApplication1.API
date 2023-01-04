namespace WebApplication1.Models
{
    public class LocalGroup
    {
        public Guid LocalGroupId { get; set; }
        public string Name { get; set; } = null!;
        public Guid UniversityId { get; set; }
        public University University { get; set; } = null!;
        public ICollection<Person>? Persons { get; set; }

    }
}

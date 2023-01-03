namespace WebApplication1.Models
{
    public class University
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Person> Persons { get; set; }
    }
}

namespace WebApplication1.Models
{
    public class Position
    {
        public Guid PositionId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Person>? Persons { get; set; }
        //public LocalGroup LocalGroupId { get; set; } = null!;

    }
}

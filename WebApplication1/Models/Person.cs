using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; } = null!;
        public string? Surname { get; set; }
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public string PhoneNumber { get; set; } = null!;

        
        public Guid RegionId { get; set; }
        public Region Region { get; set; } = null!;
        
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = null!;

        public Guid CityId { get; set; }
        public City City { get; set; } = null!;

        public Guid UniversityId { get; set; }
        public University University { get; set; } = null!;

        public Guid LocalGroupId { get; set; }
        public LocalGroup LocalGroup { get; set; } = null!;

        public Guid PositionId { get; set; }
        public Position Position { get; set; } = null!; 
        
    }
}

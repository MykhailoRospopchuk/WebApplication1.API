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
        /*
        public Region RegionId { get; set; } = null!;
        public Country CountryId { get; set; } = null!;
        public City CityId { get; set; } = null!;
        */
        public University UniversityId { get; set; } = null!;
        public Position PositionId { get; set; } = null!; 
        
    }
}

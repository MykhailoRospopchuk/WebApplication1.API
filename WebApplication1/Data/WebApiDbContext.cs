using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApiDbContext : DbContext
    {
        public DbSet<LocalGroup> LocalGroups { get; set; } = null!;
        public DbSet<University> Universities { get; set; } = null!;
        public DbSet<City> Citys { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            // if we don't use migration -> uncomment next row to create DB
            Database.EnsureCreated(); // create database on first using
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Region> regionsList = new()
            {
                new Region { RegionId = Guid.NewGuid(), RegionName = "Baltic" },
                new Region { RegionId = Guid.NewGuid(), RegionName = "Central" }
            };
            List<Country> countriesList = new()
            {
                new Country { CountryId = Guid.NewGuid(), Name = "Ukraine" },
                new Country { CountryId = Guid.NewGuid(), Name = "Germany" }
            };
            List<City> citiesList = new()
            {
                new City { CityId = Guid.NewGuid(), Name = "Kyiv" },
                new City { CityId = Guid.NewGuid(), Name = "Lviv" }
            };
            List<University> universitiesList = new()
            { new University { UniversityId = Guid.NewGuid(), Name = "KPI" },
                new University { UniversityId = Guid.NewGuid(), Name = "LPI" }
            };
            List<LocalGroup> localGroupsList = new()
            {
                new LocalGroup { LocalGroupId = Guid.NewGuid(), Name = "LG Kyiv" },
                new LocalGroup { LocalGroupId = Guid.NewGuid(), Name = "LG Lviv" }
            };
            List<Position> positionsList = new()
            {
                new Position { PositionId = Guid.NewGuid(), Name = "President" },
                new Position { PositionId = Guid.NewGuid(), Name = "VP of finances" },
                new Position { PositionId = Guid.NewGuid(), Name = "Member" }
            };
            List<Person> personsList = new()
            {
                new Person { PersonId = Guid.NewGuid(), Age = 23, Name = "Anton", Surname = "Nebuybaba", Email = "antonnebuybaba@gmail.com", PhoneNumber = "+0967756482", UniversityId = universitiesList[0], PositionId = positionsList[0] },
                new Person { PersonId = Guid.NewGuid(), Age = 25, Name = "Ivan", Surname = "Sirko", Email = "ivansirko@gmail.com", PhoneNumber = "+0964477582", UniversityId = universitiesList[0], PositionId = positionsList[0] },
                new Person { PersonId = Guid.NewGuid(), Age = 20, Name = "Oleg", Surname = "Prydubaylo", Email = "olegprydubaylo@gmail.com", PhoneNumber = "+0854753217", UniversityId = universitiesList[0], PositionId = positionsList[2] },
                new Person { PersonId = Guid.NewGuid(), Age = 19, Name = "Olga", Surname = "Prydubaylo", Email = "olgaprydubaylo@gmail.com", PhoneNumber = "+0324785107", UniversityId = universitiesList[0], PositionId = positionsList[2] },
                new Person { PersonId = Guid.NewGuid(), Age = 18, Name = "Andrew", Surname = "Glinko", Email = "andrewglicko@gmail.com", PhoneNumber = "+0321151076", UniversityId = universitiesList[0], PositionId = positionsList[2] }
            };

            modelBuilder.Entity<Region>().HasData(regionsList);
            modelBuilder.Entity<Country>().HasData(countriesList);
            modelBuilder.Entity<City>().HasData(citiesList);
            modelBuilder.Entity<University>().HasData(universitiesList);
            modelBuilder.Entity<LocalGroup>().HasData(localGroupsList);
            modelBuilder.Entity<Position>().HasData(positionsList);
           


            modelBuilder.Entity<Person>().HasData(personsList);

        }
    }   
}

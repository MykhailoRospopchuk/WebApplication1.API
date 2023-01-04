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
            Database.EnsureDeleted();
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
                new Country { CountryId = Guid.NewGuid(), Name = "Ukraine", RegionId = regionsList[0].RegionId },
                new Country { CountryId = Guid.NewGuid(), Name = "Germany", RegionId = regionsList[1].RegionId }
            };
            List<City> citiesList = new()
            {
                new City { CityId = Guid.NewGuid(), Name = "Kyiv", CountryId = countriesList[0].CountryId },
                new City { CityId = Guid.NewGuid(), Name = "Lviv", CountryId = countriesList[0].CountryId }
            };
            List<University> universitiesList = new()
            { new University { UniversityId = Guid.NewGuid(), Name = "KPI", CityId = citiesList[0].CityId },
                new University { UniversityId = Guid.NewGuid(), Name = "LPI", CityId = citiesList[1].CityId }
            };
            List<LocalGroup> localGroupsList = new()
            {
                new LocalGroup { LocalGroupId = Guid.NewGuid(), Name = "LG Kyiv", UniversityId = universitiesList[0].UniversityId },
                new LocalGroup { LocalGroupId = Guid.NewGuid(), Name = "LG Lviv", UniversityId = universitiesList[1].UniversityId  }
            };
            List<Position> positionsList = new()
            {
                new Position { PositionId = Guid.NewGuid(), Name = "President" },
                new Position { PositionId = Guid.NewGuid(), Name = "VP of finances" },
                new Position { PositionId = Guid.NewGuid(), Name = "Member" }
            };
            List<Person> personsList = new()
            { 
                new Person { 
                    PersonId = Guid.NewGuid(), 
                    Age = 23, Name = "Anton", 
                    Surname = "Nebuybaba", 
                    Email = "antonnebuybaba@gmail.com", 
                    PhoneNumber = "+0967756482",
                    RegionId = regionsList[0].RegionId,
                    CountryId = countriesList[0].CountryId,
                    CityId = citiesList[0].CityId,
                    UniversityId = universitiesList[0].UniversityId,
                    LocalGroupId = localGroupsList[0].LocalGroupId,
                    PositionId = positionsList[0].PositionId 
                },
                new Person { 
                    PersonId = Guid.NewGuid(), 
                    Age = 25, Name = "Ivan", Surname = "Sirko", 
                    Email = "ivansirko@gmail.com", 
                    PhoneNumber = "+0964477582",
                    RegionId = regionsList[0].RegionId,
                    CountryId = countriesList[0].CountryId,
                    CityId = citiesList[0].CityId,
                    UniversityId = universitiesList[0].UniversityId,
                    LocalGroupId = localGroupsList[0].LocalGroupId,
                    PositionId = positionsList[0].PositionId 
                },
                new Person { 
                    PersonId = Guid.NewGuid(), 
                    Age = 20, Name = "Oleg", Surname = "Prydubaylo", 
                    Email = "olegprydubaylo@gmail.com", 
                    PhoneNumber = "+0854753217",
                    RegionId = regionsList[0].RegionId,
                    CountryId = countriesList[0].CountryId,
                    CityId = citiesList[1].CityId,
                    UniversityId = universitiesList[1].UniversityId,
                    LocalGroupId = localGroupsList[1].LocalGroupId,
                    PositionId = positionsList[2].PositionId 
                },
                new Person { 
                    PersonId = Guid.NewGuid(), 
                    Age = 19, Name = "Olga", Surname = "Prydubaylo", 
                    Email = "olgaprydubaylo@gmail.com", 
                    PhoneNumber = "+0324785107",
                    RegionId = regionsList[0].RegionId, 
                    CountryId = countriesList[0].CountryId, 
                    CityId = citiesList[0].CityId, 
                    UniversityId = universitiesList[0].UniversityId, 
                    LocalGroupId = localGroupsList[0].LocalGroupId, 
                    PositionId = positionsList[2].PositionId 
                },
                new Person { 
                    PersonId = Guid.NewGuid(), 
                    Age = 18, Name = "Andrew", Surname = "Glinko", 
                    Email = "andrewglicko@gmail.com",
                    PhoneNumber = "+0321151076", 
                    RegionId = regionsList[0].RegionId, 
                    CountryId = countriesList[0].CountryId, 
                    CityId = citiesList[1].CityId, 
                    UniversityId = universitiesList[0].UniversityId, 
                    LocalGroupId = localGroupsList[0].LocalGroupId, 
                    PositionId = positionsList[2].PositionId 
                }
            };
            
            modelBuilder.Entity<Person>()
                .HasOne(l => l.LocalGroup)
                .WithMany(p => p.Persons)
                .HasForeignKey(l => l.LocalGroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Person>()
                .HasOne(u => u.University)
                .WithMany(p => p.Persons)
                .HasForeignKey(u => u.UniversityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Person>()
                .HasOne(c => c.City)
                .WithMany(p => p.Persons)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Person>()
                .HasOne(c => c.Country)
                .WithMany(p => p.Persons)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Person>()
                .HasOne(r => r.Region)
                .WithMany(p => p.Persons)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Position)
                .WithMany(p => p.Persons)
                .HasForeignKey(p => p.PositionId);

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

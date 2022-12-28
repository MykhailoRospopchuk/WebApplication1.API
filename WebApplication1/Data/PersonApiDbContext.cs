using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PersonApiDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public PersonApiDbContext(DbContextOptions<PersonApiDbContext> options) : base(options) 
        {
            Database.EnsureCreated(); // create database on first using
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                    new Person { Id = Guid.NewGuid(), Age = 23, Name = "Anton", Surname = "Nebuybaba", Email = "antonnebuybaba@gmail.com", PhoneNumber = "+0967756482"}
                );
        }
    }
}

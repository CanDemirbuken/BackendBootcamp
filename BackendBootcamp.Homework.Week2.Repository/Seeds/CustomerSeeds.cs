using BackendBootcamp.Homework.Week2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendBootcamp.Homework.Week2.Repository.Seeds
{
    public class CustomerSeeds : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890", Address = "123 Main St", BirthYear = 1985 },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210", Address = "456 Elm St", BirthYear = 1990 },
                new Customer { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "555-555-5555", Address = "789 Oak St", BirthYear = 1975 },
                new Customer { Id = 4, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", PhoneNumber = "444-444-4444", Address = "101 Pine St", BirthYear = 1988 },
                new Customer { Id = 5, FirstName = "David", LastName = "Brown", Email = "david.brown@example.com", PhoneNumber = "333-333-3333", Address = "202 Maple St", BirthYear = 1992 },
                new Customer { Id = 6, FirstName = "Linda", LastName = "Taylor", Email = "linda.taylor@example.com", PhoneNumber = "222-222-2222", Address = "303 Cedar St", BirthYear = 1980 },
                new Customer { Id = 7, FirstName = "James", LastName = "Anderson", Email = "james.anderson@example.com", PhoneNumber = "111-111-1111", Address = "404 Birch St", BirthYear = 1970 },
                new Customer { Id = 8, FirstName = "Sarah", LastName = "Thomas", Email = "sarah.thomas@example.com", PhoneNumber = "666-666-6666", Address = "505 Spruce St", BirthYear = 1983 },
                new Customer { Id = 9, FirstName = "Christopher", LastName = "Moore", Email = "christopher.moore@example.com", PhoneNumber = "777-777-7777", Address = "606 Fir St", BirthYear = 1995 },
                new Customer { Id = 10, FirstName = "Laura", LastName = "Martin", Email = "laura.martin@example.com", PhoneNumber = "888-888-8888", Address = "707 Redwood St", BirthYear = 1987 }
            );
        }
    }
}

using BackendBootcamp.Homework.Week2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendBootcamp.Homework.Week2.Repository.Seeds
{
    public class EmployeeSeeds : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee { Id = 1, FirstName = "Alice", LastName = "Johnson", Title = "Software Engineer", GrossSalary = 75000M },
                new Employee { Id = 2, FirstName = "Bob", LastName = "Smith", Title = "Project Manager", GrossSalary = 85000M },
                new Employee { Id = 3, FirstName = "Charlie", LastName = "Brown", Title = "QA Engineer", GrossSalary = 60000M },
                new Employee { Id = 4, FirstName = "Diana", LastName = "Prince", Title = "Product Owner", GrossSalary = 95000M },
                new Employee { Id = 5, FirstName = "Eve", LastName = "Davis", Title = "Business Analyst", GrossSalary = 70000M },
                new Employee { Id = 6, FirstName = "Frank", LastName = "Miller", Title = "DevOps Engineer", GrossSalary = 80000M },
                new Employee { Id = 7, FirstName = "Grace", LastName = "Lee", Title = "UI/UX Designer", GrossSalary = 65000M },
                new Employee { Id = 8, FirstName = "Hank", LastName = "Williams", Title = "Database Administrator", GrossSalary = 77000M },
                new Employee { Id = 9, FirstName = "Ivy", LastName = "Taylor", Title = "HR Manager", GrossSalary = 68000M },
                new Employee { Id = 10, FirstName = "Jack", LastName = "Wilson", Title = "IT Support Specialist", GrossSalary = 55000M }
            );
        }
    }
}

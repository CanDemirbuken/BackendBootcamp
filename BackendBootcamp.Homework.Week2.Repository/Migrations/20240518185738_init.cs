using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendBootcamp.Homework.Week2.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, "George Orwell", 19.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7831), "1984" },
                    { 2, "Harper Lee", 14.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7843), "To Kill a Mockingbird" },
                    { 3, "F. Scott Fitzgerald", 10.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7845), "The Great Gatsby" },
                    { 4, "Herman Melville", 15.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7846), "Moby Dick" },
                    { 5, "Leo Tolstoy", 20.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7847), "War and Peace" },
                    { 6, "Jane Austen", 9.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7848), "Pride and Prejudice" },
                    { 7, "J.D. Salinger", 12.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7850), "The Catcher in the Rye" },
                    { 8, "J.R.R. Tolkien", 14.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7851), "The Hobbit" },
                    { 9, "James Joyce", 16.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7853), "Ulysses" },
                    { 10, "Homer", 18.99m, new DateTime(2024, 5, 18, 21, 57, 37, 989, DateTimeKind.Local).AddTicks(7854), "The Odyssey" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "BirthYear", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", 1985, "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "456 Elm St", 1990, "jane.smith@example.com", "Jane", "Smith", "987-654-3210" },
                    { 3, "789 Oak St", 1975, "michael.johnson@example.com", "Michael", "Johnson", "555-555-5555" },
                    { 4, "101 Pine St", 1988, "emily.davis@example.com", "Emily", "Davis", "444-444-4444" },
                    { 5, "202 Maple St", 1992, "david.brown@example.com", "David", "Brown", "333-333-3333" },
                    { 6, "303 Cedar St", 1980, "linda.taylor@example.com", "Linda", "Taylor", "222-222-2222" },
                    { 7, "404 Birch St", 1970, "james.anderson@example.com", "James", "Anderson", "111-111-1111" },
                    { 8, "505 Spruce St", 1983, "sarah.thomas@example.com", "Sarah", "Thomas", "666-666-6666" },
                    { 9, "606 Fir St", 1995, "christopher.moore@example.com", "Christopher", "Moore", "777-777-7777" },
                    { 10, "707 Redwood St", 1987, "laura.martin@example.com", "Laura", "Martin", "888-888-8888" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "GrossSalary", "LastName", "Title" },
                values: new object[,]
                {
                    { 1, "Alice", 75000m, "Johnson", "Software Engineer" },
                    { 2, "Bob", 85000m, "Smith", "Project Manager" },
                    { 3, "Charlie", 60000m, "Brown", "QA Engineer" },
                    { 4, "Diana", 95000m, "Prince", "Product Owner" },
                    { 5, "Eve", 70000m, "Davis", "Business Analyst" },
                    { 6, "Frank", 80000m, "Miller", "DevOps Engineer" },
                    { 7, "Grace", 65000m, "Lee", "UI/UX Designer" },
                    { 8, "Hank", 77000m, "Williams", "Database Administrator" },
                    { 9, "Ivy", 68000m, "Taylor", "HR Manager" },
                    { 10, "Jack", 55000m, "Wilson", "IT Support Specialist" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

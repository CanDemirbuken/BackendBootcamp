using BackendBootcamp.Homework.Week2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BackendBootcamp.Homework.Week2.Repository.Seeds
{
    public class BookSeeds : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", PublicationDate = DateTime.Now, Price = 19.99M },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationDate = DateTime.Now, Price = 14.99M },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationDate = DateTime.Now, Price = 10.99M },
                new Book { Id = 4, Title = "Moby Dick", Author = "Herman Melville", PublicationDate = DateTime.Now, Price = 15.99M },
                new Book { Id = 5, Title = "War and Peace", Author = "Leo Tolstoy", PublicationDate = DateTime.Now, Price = 20.99M },
                new Book { Id = 6, Title = "Pride and Prejudice", Author = "Jane Austen", PublicationDate = DateTime.Now, Price = 9.99M },
                new Book { Id = 7, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublicationDate = DateTime.Now, Price = 12.99M },
                new Book { Id = 8, Title = "The Hobbit", Author = "J.R.R. Tolkien", PublicationDate = DateTime.Now, Price = 14.99M },
                new Book { Id = 9, Title = "Ulysses", Author = "James Joyce", PublicationDate = DateTime.Now, Price = 16.99M },
                new Book { Id = 10, Title = "The Odyssey", Author = "Homer", PublicationDate = DateTime.Now, Price = 18.99M }
            );
        }
    }
}

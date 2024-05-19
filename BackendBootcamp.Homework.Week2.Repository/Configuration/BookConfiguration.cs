using BackendBootcamp.Homework.Week2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Repository.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn();

            builder.Property(b => b.Title).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Author).IsRequired().HasMaxLength(50);
            builder.Property(b => b.PublicationDate).IsRequired().HasColumnType("datetime");
            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
    }
}

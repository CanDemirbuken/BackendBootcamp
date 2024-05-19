using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Title { get; set; } = default!;
        public decimal GrossSalary { get; set; }
    }

}

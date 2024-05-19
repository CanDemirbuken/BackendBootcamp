using BackendBootcamp.Homework.Week2.Core.Entities;
using BackendBootcamp.Homework.Week2.Core.Repositories;

namespace BackendBootcamp.Homework.Week2.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}

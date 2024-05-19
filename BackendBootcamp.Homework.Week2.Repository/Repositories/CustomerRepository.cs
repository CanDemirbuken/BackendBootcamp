using BackendBootcamp.Homework.Week2.Core.Entities;
using BackendBootcamp.Homework.Week2.Core.Repositories;

namespace BackendBootcamp.Homework.Week2.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}

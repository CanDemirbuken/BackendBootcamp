using BackendBootcamp.Homework.Week2.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public void Commit() => context.SaveChanges();
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}

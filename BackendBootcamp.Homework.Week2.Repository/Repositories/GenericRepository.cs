using BackendBootcamp.Homework.Week2.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendBootcamp.Homework.Week2.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity) => _dbSet.Add(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _dbSet.AnyAsync(predicate);
        public Task<IQueryable<T>> GetAllAsync() => Task.FromResult(_dbSet.AsNoTracking().AsQueryable());
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public void Update(T entity) => _dbSet.Update(entity);
    }
}

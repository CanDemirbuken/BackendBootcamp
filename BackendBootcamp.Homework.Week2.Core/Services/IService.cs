using BackendBootcamp.Homework.Week2.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Core.Services
{
    public interface IService<Entity, Dto> where Entity : class where Dto : class
    {
        Task<CustomResponseDTO<IEnumerable<Dto>>> GetAllAsync();
        Task<CustomResponseDTO<Dto>> GetByIdAsync(int id);
        Task<CustomResponseDTO<NoContent>> RemoveAsync(int id);
        Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Dto, bool>> predicate);
    }
}

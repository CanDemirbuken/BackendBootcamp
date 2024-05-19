using AutoMapper;
using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.Repositories;
using BackendBootcamp.Homework.Week2.Core.Services;
using BackendBootcamp.Homework.Week2.Core.UnitOfWorks;
using BackendBootcamp.Homework.Week2.Service.Exceptions;
using System.Linq.Expressions;
using System.Net;

namespace BackendBootcamp.Homework.Week2.Service.Services
{
    public class Service<Entity, Dto> : IService<Entity, Dto> where Entity : class where Dto : class
    {
        protected readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly RedisService _redisService;

        public Service(IGenericRepository<Entity> repository, IUnitOfWork unitOfWork, IMapper mapper, RedisService redisService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisService = redisService;
        }

        public async Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Dto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<Entity, bool>>>(predicate);
            var result = await _repository.AnyAsync(entityPredicate);

            return CustomResponseDTO<bool>.Success(result, HttpStatusCode.OK);
        }

        public async Task<CustomResponseDTO<IEnumerable<Dto>>> GetAllAsync()
        {
            string cacheKey = $"{typeof(Dto).Name.ToLower()}_all_dtos";
            var cachedDtos = await _redisService.GetCacheAsync<IEnumerable<Dto>>(cacheKey);

            if (cachedDtos != null)
            {
                return CustomResponseDTO<IEnumerable<Dto>>.Success(cachedDtos, HttpStatusCode.OK);
            }

            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<Dto>>(entities);

            await _redisService.SetCacheAsync(cacheKey, dtos, TimeSpan.FromMinutes(10));
            return CustomResponseDTO<IEnumerable<Dto>>.Success(dtos, HttpStatusCode.OK);
        }

        public async Task<CustomResponseDTO<Dto>> GetByIdAsync(int id)
        {
            string cacheKey = $"{typeof(Dto).Name.ToLower()}_dto:{id}";
            var cacheDto = await _redisService.GetCacheAsync<Dto>(cacheKey);

            if (cacheDto != null)
            {
                return CustomResponseDTO<Dto>.Success(cacheDto, HttpStatusCode.OK);
            }

            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new NotFoundException($"{typeof(Entity).Name}({id}) bulunamadı.");
            }

            var dto = _mapper.Map<Dto>(entity);
            await _redisService.SetCacheAsync(cacheKey, dto, TimeSpan.FromMinutes(10));
            return CustomResponseDTO<Dto>.Success(dto, HttpStatusCode.OK);
        }


        public async Task<CustomResponseDTO<NoContent>> RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new NotFoundException($"{typeof(Entity).Name}({id}) bulunamadı.");
            }

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}

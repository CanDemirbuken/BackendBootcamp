using AutoMapper;
using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;
using BackendBootcamp.Homework.Week2.Core.Repositories;
using BackendBootcamp.Homework.Week2.Core.Services;
using BackendBootcamp.Homework.Week2.Core.UnitOfWorks;
using System.Net;

namespace BackendBootcamp.Homework.Week2.Service.Services
{
    public class BookService : Service<Book, BookDTO>, IBookService
    {
        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork, IMapper mapper, RedisService redis) : base(repository, unitOfWork, mapper, redis)
        {
        }

        public async Task<CustomResponseDTO<BookCreateRequestDTO>> AddBookAsync(BookCreateRequestDTO request)
        {
            var book = _mapper.Map<Book>(request);
            _repository.Add(book);
            await _unitOfWork.CommitAsync();

            var bookDTO = _mapper.Map<BookCreateRequestDTO>(book);

            return CustomResponseDTO<BookCreateRequestDTO>.Success(bookDTO, HttpStatusCode.Created);
        }

        public async Task<CustomResponseDTO<NoContent>> UpdateBookAsync(BookUpdateRequestDTO request)
        {
            var book = _mapper.Map<Book>(request);
            _repository.Update(book);
            await _unitOfWork.CommitAsync();

            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}

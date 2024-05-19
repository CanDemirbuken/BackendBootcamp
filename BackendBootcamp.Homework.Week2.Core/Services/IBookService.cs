using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Core.Services
{
    public interface IBookService : IService<Book, BookDTO>
    {
        Task<CustomResponseDTO<BookCreateRequestDTO>> AddBookAsync(BookCreateRequestDTO request);
        Task<CustomResponseDTO<NoContent>> UpdateBookAsync(BookUpdateRequestDTO request);
    }
}

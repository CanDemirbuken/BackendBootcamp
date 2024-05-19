using BackendBootcamp.Homework.Week2.API.Filters;
using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;
using BackendBootcamp.Homework.Week2.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendBootcamp.Homework.Week2.API.Controllers
{
    public class BooksController : CustomBaseController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks() => CreateActionResult(await _bookService.GetAllAsync());

        [ServiceFilter(typeof(NotFoundFilter<Book, BookDTO>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id) => CreateActionResult(await _bookService.GetByIdAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookUpdateRequestDTO request) => CreateActionResult(await _bookService.UpdateBookAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id) => CreateActionResult(await _bookService.RemoveAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddBook(BookCreateRequestDTO request)
        {
            var result = await _bookService.AddBookAsync(request);
            return CreateActionResult(result, nameof(GetBookById), new { id = result.Data });
        }
    }
}

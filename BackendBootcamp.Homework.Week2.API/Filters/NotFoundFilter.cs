using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using BackendBootcamp.Homework.Week2.Core.Repositories;
using BackendBootcamp.Homework.Week2.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BackendBootcamp.Homework.Week2.API.Filters
{
    public class NotFoundFilter<Entity, Dto> : Attribute, IActionFilter where Entity : class where Dto : class
    {
        private readonly IBookRepository _bookRepository;

        public NotFoundFilter(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

            var bookIdFromAction = context.ActionArguments.Values.First()!;
            int bookId = 0;

            if (actionName == "GetBookById" && bookIdFromAction is BookDTO bookDto)
            {
                bookId = bookDto.Id;
            }


            if (bookId == 0 && !int.TryParse(bookIdFromAction.ToString(), out bookId))
            {
                return;
            }

            var hasProduct = _bookRepository.GetByIdAsync(bookId).Result;

            if (hasProduct is null)
            {
                var errorMessage = $"There is no book with id: {bookId}";

                var responseModel = CustomResponseDTO<NoContent>.Fail(HttpStatusCode.NotFound, errorMessage);
                context.Result = new NotFoundObjectResult(responseModel);
            }
        }
    }
}

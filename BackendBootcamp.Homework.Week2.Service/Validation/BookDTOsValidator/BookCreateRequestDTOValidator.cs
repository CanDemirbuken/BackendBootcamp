using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using FluentValidation;

namespace BackendBootcamp.Homework.Week2.Service.Validation.BookDTOsValidator
{
    public class BookCreateRequestDTOValidator : AbstractValidator<BookCreateRequestDTO>
    {
        public BookCreateRequestDTOValidator()
        {
            RuleFor(b => b.Title).NotNull().WithMessage("{ProperyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(b => b.Author).NotNull().WithMessage("{ProperyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(b => b.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}

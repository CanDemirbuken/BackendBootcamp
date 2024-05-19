using BackendBootcamp.Homework.Week2.Core.DTOs.BookDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Service.Validation.BookDTOsValidator
{
    public class BookUpdateRequestDTOValidator : AbstractValidator<BookUpdateRequestDTO>
    {
        public BookUpdateRequestDTOValidator()
        {
            RuleFor(b => b.Title).NotNull().WithMessage("{ProperyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(b => b.Author).NotNull().WithMessage("{ProperyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(b => b.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}

using BackendBootcamp.Homework.Week2.Core.DTOs.CustomerDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Service.Validation.CustomerDTOsValidator
{
    public class CustomerCreateRequestDTOValidator : AbstractValidator<CustomerCreateRequestDTO>
    {
        public CustomerCreateRequestDTOValidator()
        {
            RuleFor(c => c.FirstName).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.LastName).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.Email).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.PhoneNumber).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.Address).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.BirthYear).InclusiveBetween(1900, int.MaxValue).WithMessage("{PropertyName} must be greater than 1900.");
        }
    }
}

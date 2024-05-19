using BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Service.Validation.EmployeeDTOsValidator
{
    public class EmployeeUpdateRequestDTOValidator : AbstractValidator<EmployeeUpdateRequestDTO>
    {
        public EmployeeUpdateRequestDTOValidator()
        {
            RuleFor(c => c.FirstName).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.LastName).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.Title).NotNull().WithMessage("{PropertyName} can not be null.").NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(c => c.GrossSalary).InclusiveBetween(10000, int.MaxValue).WithMessage("{PropertyName} must be greater than 10000.");
        }
    }
}

using BackendBootcamp.Homework.Week2.Core.DTOs.CustomerDTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendBootcamp.Homework.Week2.Core.Services
{
    public interface IEmployeeService : IService<Employee, EmployeeDTO>
    {
        Task<CustomResponseDTO<EmployeeCreateRequestDTO>> AddEmployeeAsync(EmployeeCreateRequestDTO request);
        Task<CustomResponseDTO<NoContent>> UpdateEmployeeAsync(EmployeeUpdateRequestDTO request);
    }
}

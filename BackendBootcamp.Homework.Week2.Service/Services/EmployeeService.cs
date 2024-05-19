using AutoMapper;
using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;
using BackendBootcamp.Homework.Week2.Core.Repositories;
using BackendBootcamp.Homework.Week2.Core.Services;
using BackendBootcamp.Homework.Week2.Core.UnitOfWorks;
using System.Net;

namespace BackendBootcamp.Homework.Week2.Service.Services
{
    public class EmployeeService : Service<Employee, EmployeeDTO>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper, RedisService redis) : base(repository, unitOfWork, mapper, redis)
        {
        }

        public async Task<CustomResponseDTO<EmployeeCreateRequestDTO>> AddEmployeeAsync(EmployeeCreateRequestDTO request)
        {
            var employee = _mapper.Map<Employee>(request);
            _repository.Add(employee);
            await _unitOfWork.CommitAsync();

            var employeeDTO = _mapper.Map<EmployeeCreateRequestDTO>(employee);
            return CustomResponseDTO<EmployeeCreateRequestDTO>.Success(employeeDTO, HttpStatusCode.Created);
        }

        public async Task<CustomResponseDTO<NoContent>> UpdateEmployeeAsync(EmployeeUpdateRequestDTO request)
        {
            var employee = _mapper.Map<Employee>(request);
            _repository.Update(employee);
            await _unitOfWork.CommitAsync();

            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}

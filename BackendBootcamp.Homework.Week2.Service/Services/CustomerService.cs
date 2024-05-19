using AutoMapper;
using BackendBootcamp.Homework.Week2.Core.DTOs;
using BackendBootcamp.Homework.Week2.Core.DTOs.CustomerDTOs;
using BackendBootcamp.Homework.Week2.Core.Entities;
using BackendBootcamp.Homework.Week2.Core.Repositories;
using BackendBootcamp.Homework.Week2.Core.Services;
using BackendBootcamp.Homework.Week2.Core.UnitOfWorks;
using System.Net;

namespace BackendBootcamp.Homework.Week2.Service.Services
{
    public class CustomerService : Service<Customer, CustomerDTO>, ICustomerService
    {
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, RedisService redis) : base(repository, unitOfWork, mapper, redis)
        {
        }

        public async Task<CustomResponseDTO<CustomerCreateRequestDTO>> AddCustomerAsync(CustomerCreateRequestDTO request)
        {
            var customer = _mapper.Map<Customer>(request);
            _repository.Add(customer);
            await _unitOfWork.CommitAsync();

            var customerDTO = _mapper.Map<CustomerCreateRequestDTO>(customer);

            return CustomResponseDTO<CustomerCreateRequestDTO>.Success(customerDTO, HttpStatusCode.Created);
        }

        public async Task<CustomResponseDTO<NoContent>> UpdateCustomerAsync(CustomerUpdateRequestDTO request)
        {
            var customer = _mapper.Map<Customer>(request);
            _repository.Update(customer);
            await _unitOfWork.CommitAsync();

            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}

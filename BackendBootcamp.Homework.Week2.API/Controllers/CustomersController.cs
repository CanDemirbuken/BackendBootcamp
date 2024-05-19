using BackendBootcamp.Homework.Week2.Core.DTOs.CustomerDTOs;
using BackendBootcamp.Homework.Week2.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendBootcamp.Homework.Week2.API.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers() => CreateActionResult(await _customerService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id) => CreateActionResult(await _customerService.GetByIdAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateRequestDTO request) => CreateActionResult(await _customerService.UpdateCustomerAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id) => CreateActionResult(await _customerService.RemoveAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerCreateRequestDTO request)
        {
            var result = await _customerService.AddCustomerAsync(request);
            return CreateActionResult(result, nameof(GetCustomerById), new { id = result.Data });
        }
    }
}

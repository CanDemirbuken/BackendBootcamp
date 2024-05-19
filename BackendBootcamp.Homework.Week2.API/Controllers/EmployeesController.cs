using BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs;
using BackendBootcamp.Homework.Week2.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendBootcamp.Homework.Week2.API.Controllers
{
    public class EmployeesController : CustomBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees() => CreateActionResult(await _employeeService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id) => CreateActionResult(await _employeeService.GetByIdAsync(id));

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateRequestDTO request) => CreateActionResult(await _employeeService.UpdateEmployeeAsync(request));

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id) => CreateActionResult(await _employeeService.RemoveAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeCreateRequestDTO request)
        {
            var result = await _employeeService.AddEmployeeAsync(request);
            return CreateActionResult(result, nameof(GetEmployeeById), new { id = result.Data });
        }
    }
}

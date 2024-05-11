using BackendBootcamp.Homework.Week1.API.Controllers;
using BackendBootcamp.Homework.Week1.API.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBootcamp.Homework.Week1.API.Users
{
    public class UsersController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] BirthYearCalculator calculator) => CreateActionResult(_userService.GetAllWithRole(calculator));

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] BirthYearCalculator calculator) => CreateActionResult(_userService.GetByIdWithRole(id, calculator));

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserUpdateRequestDTO request) => CreateActionResult(_userService.Update(id, request));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => CreateActionResult(_userService.Delete(id));

        [HttpPost]
        public IActionResult Add(UserCreateRequestDTO request)
        {
            var result = _userService.Add(request);
            return CreateActionResult(result, nameof(GetById), new { id = result.Data });
        }
    }
}

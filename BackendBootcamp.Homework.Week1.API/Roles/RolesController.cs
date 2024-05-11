using BackendBootcamp.Homework.Week1.API.Controllers;
using BackendBootcamp.Homework.Week1.API.Roles.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendBootcamp.Homework.Week1.API.Roles
{
    public class RolesController : CustomBaseController
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll() => CreateActionResult(_roleService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => CreateActionResult(_roleService.GetById(id));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => CreateActionResult(_roleService.Delete(id));

        [HttpPut("{id}")]
        public IActionResult Update(int id, RoleUpdateRequestDTO request) => CreateActionResult(_roleService.Update(id, request));

        [HttpPost]
        public IActionResult Add(RoleCreateRequestDTO request)
        {
            var result = _roleService.Add(request);
            return CreateActionResult(result, nameof(RolesController.GetById), new { id = result.Data });
        }
    }
}

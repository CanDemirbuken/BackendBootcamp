using BackendBootcamp.Homework.Week2.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackendBootcamp.Homework.Week2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> response)
        {
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null) { StatusCode = 204 };
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }

        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> response, string methodName, object routeValues)
        {
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return CreatedAtAction(methodName, routeValues, response);
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }
    }
}

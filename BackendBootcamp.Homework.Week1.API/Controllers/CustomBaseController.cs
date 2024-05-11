using BackendBootcamp.Homework.Week1.API.SharedDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BackendBootcamp.Homework.Week1.API.Controllers
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

        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> response, string methodName, object routeValue)
        {
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return CreatedAtAction(methodName, routeValue, response);
            }

            return new ObjectResult(response) { StatusCode = (int)response.StatusCode };
        }
    }
}

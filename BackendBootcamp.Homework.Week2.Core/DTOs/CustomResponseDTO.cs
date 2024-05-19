using System.Net;
using System.Text.Json.Serialization;

namespace BackendBootcamp.Homework.Week2.Core.DTOs
{
    public struct NoContent;
    public class CustomResponseDTO<T>
    {
        public T? Data { get; set; }
        [JsonIgnore] public HttpStatusCode StatusCode { get; set; }
        public List<string>? ErrorMessages { get; set; }

        public static CustomResponseDTO<T> Success(T data, HttpStatusCode statusCode)
        {
            return new CustomResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }

        public static CustomResponseDTO<T> Success(HttpStatusCode statusCode)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode
            };
        }

        public static CustomResponseDTO<T> Fail(HttpStatusCode statusCode, List<string> messages)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                ErrorMessages = messages
            };
        }

        public static CustomResponseDTO<T> Fail(HttpStatusCode statusCode, string message)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                ErrorMessages = new List<string> { message }
            };
        }
    }
}

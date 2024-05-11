using System.Net;
using System.Text.Json.Serialization;

namespace BackendBootcamp.Homework.Week1.API.SharedDTOs
{
    public struct NoContent;
    public class CustomResponseDTO<T>
    {
        public T? Data { get; set; }
        [JsonIgnore] public HttpStatusCode StatusCode { get; set; }
        public List<string>? FailMessages { get; set; }

        public static CustomResponseDTO<T> Success(T? data, HttpStatusCode statusCode)
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

        public static CustomResponseDTO<T> Fail(List<string> messages, HttpStatusCode statusCode)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                FailMessages = messages
            };
        }

        public static CustomResponseDTO<T> Fail(string message, HttpStatusCode statusCode)
        {
            return new CustomResponseDTO<T>
            {
                StatusCode = statusCode,
                FailMessages = new List<string> { message }
            };
        }
    }
}

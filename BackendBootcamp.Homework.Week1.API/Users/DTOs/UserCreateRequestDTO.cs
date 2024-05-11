namespace BackendBootcamp.Homework.Week1.API.Users.DTOs
{
    public record UserCreateRequestDTO(string FirstName, string LastName, int Age, int RoleId);
}

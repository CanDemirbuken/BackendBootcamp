namespace BackendBootcamp.Homework.Week1.API.Users.DTOs
{
    public record UserUpdateRequestDTO(int Id, string FirstName, string LastName, int Age, int RoleId);
}

namespace BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs
{
    public record EmployeeCreateRequestDTO(string FirstName, string LastName, string Title, decimal GrossSalary);
}

namespace BackendBootcamp.Homework.Week2.Core.DTOs.EmployeeDTOs
{
    public record EmployeeUpdateRequestDTO(string FirstName, string LastName, string Title, decimal GrossSalary);
}

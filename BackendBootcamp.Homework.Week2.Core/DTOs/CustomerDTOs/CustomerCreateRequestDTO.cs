namespace BackendBootcamp.Homework.Week2.Core.DTOs.CustomerDTOs
{
    public record CustomerCreateRequestDTO(string FirstName, string LastName, string Email, string PhoneNumber, string Address, int BirthYear);
}

using BackendBootcamp.Homework.Week1.API.SharedDTOs;
using BackendBootcamp.Homework.Week1.API.Users.DTOs;
using System.Collections.Immutable;

namespace BackendBootcamp.Homework.Week1.API.Users
{
    public interface IUserService
    {
        CustomResponseDTO<ImmutableList<UserDTO>> GetAllWithRole(BirthYearCalculator calculator);
        CustomResponseDTO<UserDTO> GetByIdWithRole(int id, BirthYearCalculator calculator);
        CustomResponseDTO<int> Add(UserCreateRequestDTO request);
        CustomResponseDTO<NoContent> Update(int id, UserUpdateRequestDTO request);
        CustomResponseDTO<NoContent> Delete(int id);
    }
}

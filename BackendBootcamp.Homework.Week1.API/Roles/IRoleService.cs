using BackendBootcamp.Homework.Week1.API.Roles.DTOs;
using BackendBootcamp.Homework.Week1.API.SharedDTOs;
using System.Collections.Immutable;

namespace BackendBootcamp.Homework.Week1.API.Roles
{
    public interface IRoleService
    {
        CustomResponseDTO<ImmutableList<RoleDTO>> GetAll();
        CustomResponseDTO<RoleDTO> GetById(int id);
        CustomResponseDTO<int> Add(RoleCreateRequestDTO request);
        CustomResponseDTO<NoContent> Update(int id, RoleUpdateRequestDTO request);
        CustomResponseDTO<NoContent> Delete(int id);
    }
}

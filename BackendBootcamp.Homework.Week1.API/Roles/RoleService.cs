using BackendBootcamp.Homework.Week1.API.Roles.DTOs;
using BackendBootcamp.Homework.Week1.API.SharedDTOs;
using System.Collections.Immutable;
using System.Net;

namespace BackendBootcamp.Homework.Week1.API.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public CustomResponseDTO<int> Add(RoleCreateRequestDTO request)
        {
            var newRole = new Role
            {
                Id = _roleRepository.GetAll().Count + 1,
                Name = request.Name,
            };

            _roleRepository.Create(newRole);
            return CustomResponseDTO<int>.Success(newRole.Id, HttpStatusCode.Created);
        }

        public CustomResponseDTO<NoContent> Delete(int id)
        {
            var role = _roleRepository.GetById(id);
            if (role is null)
            {
                return CustomResponseDTO<NoContent>.Fail("Silinecek rol bulunamadı.", HttpStatusCode.NotFound);
            }

            _roleRepository.Delete(id);
            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public CustomResponseDTO<ImmutableList<RoleDTO>> GetAll()
        {
            var roles = _roleRepository.GetAll();
            if (roles is null)
            {
                return CustomResponseDTO<ImmutableList<RoleDTO>>.Fail("Aranan roller bulunamadı.", HttpStatusCode.NotFound);
            }

            var rolesDto = roles.Select(x => new RoleDTO
            (
                x.Id,
                x.Name
            )).ToImmutableList();

            return CustomResponseDTO<ImmutableList<RoleDTO>>.Success(rolesDto, HttpStatusCode.OK);
        }

        public CustomResponseDTO<RoleDTO> GetById(int id)
        {
            var role = _roleRepository.GetById(id);
            if (role is null)
            {
                return CustomResponseDTO<RoleDTO>.Fail("Aranan rol bulunamadı.", HttpStatusCode.NotFound);
            }

            var roleDto = new RoleDTO
            (
                role.Id,
                role.Name
            );

            return CustomResponseDTO<RoleDTO>.Success(roleDto, HttpStatusCode.OK);
        }

        public CustomResponseDTO<NoContent> Update(int id, RoleUpdateRequestDTO request)
        {
            var role = _roleRepository.GetById(id);
            if (role is null)
            {
                return CustomResponseDTO<NoContent>.Fail("Güncellenmek istenen rol bulunamadı.", HttpStatusCode.NotFound);
            }

            var updatedRole = new Role
            {
                Id = id,
                Name = request.Name,
            };

            _roleRepository.Update(updatedRole);
            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}

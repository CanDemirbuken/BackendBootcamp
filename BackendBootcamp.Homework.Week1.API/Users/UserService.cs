using BackendBootcamp.Homework.Week1.API.Roles;
using BackendBootcamp.Homework.Week1.API.SharedDTOs;
using BackendBootcamp.Homework.Week1.API.Users.DTOs;
using System.Collections.Immutable;
using System.Net;

namespace BackendBootcamp.Homework.Week1.API.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public CustomResponseDTO<int> Add(UserCreateRequestDTO request)
        {
            var newUser = new User
            {
                Id = _userRepository.GetAll().Count + 1,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                RoleId = request.RoleId
            };

            _userRepository.Create(newUser);
            return CustomResponseDTO<int>.Success(newUser.Id, HttpStatusCode.Created);
        }

        public CustomResponseDTO<NoContent> Delete(int id)
        {
            var hasUser = _userRepository.GetById(id);
            if (hasUser is null)
            {
                return CustomResponseDTO<NoContent>.Fail("Silinecek kullanıcı bulunamadı.", HttpStatusCode.NotFound);
            }

            _userRepository.Delete(id);
            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public CustomResponseDTO<ImmutableList<UserDTO>> GetAllWithRole(BirthYearCalculator calculator)
        {
            var users = _userRepository.GetAll();
            if (users is null)
            {
                return CustomResponseDTO<ImmutableList<UserDTO>>.Fail("Kayıtlı kullanıcılar bulunamadı.", HttpStatusCode.NotFound);
            }

            var usersDto = users.Select(x => new UserDTO
            (
                x.Id,
                x.FirstName,
                x.LastName,
                calculator.GetBirthYear(x.Age),
                _roleRepository.GetById(x.RoleId)!.Name
            )).ToImmutableList();

            return CustomResponseDTO<ImmutableList<UserDTO>>.Success(usersDto, HttpStatusCode.OK);
        }

        public CustomResponseDTO<UserDTO> GetByIdWithRole(int id, BirthYearCalculator calculator)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
            {
                return CustomResponseDTO<UserDTO>.Fail("Aranan kullanıcı bulunamadı.", HttpStatusCode.NotFound);
            }

            var userDto = new UserDTO
            (
                user.Id,
                user.FirstName,
                user.LastName,
                calculator.GetBirthYear(user.Age),
                _roleRepository.GetById(user.RoleId)!.Name
            );

            return CustomResponseDTO<UserDTO>.Success(userDto, HttpStatusCode.OK);
        }

        public CustomResponseDTO<NoContent> Update(int id, UserUpdateRequestDTO request)
        {
            var hasUser = _userRepository.GetById(id);
            if (hasUser is null)
            {
                return CustomResponseDTO<NoContent>.Fail("Güncellenmek istenen kullanıcı bulunamadı.", HttpStatusCode.NotFound);
            }

            var updatedUser = new User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                RoleId = request.RoleId
            };

            _userRepository.Update(updatedUser);
            return CustomResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }
    }
}

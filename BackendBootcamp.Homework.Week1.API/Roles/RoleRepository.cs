namespace BackendBootcamp.Homework.Week1.API.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private static List<Role> _roles =
        [
            new Role {Id = 1, Name = "Admin"},
            new Role {Id = 2, Name = "Manager"},
            new Role {Id = 3, Name = "Operator"}
        ];

        public void Create(Role role) => _roles.Add(role);
        public IReadOnlyList<Role> GetAll() => _roles;
        public Role? GetById(int id) => _roles.Find(r => r.Id == id);

        public void Update(Role role)
        {
            var index = _roles.FindIndex(r => r.Id == role.Id);
            _roles[index] = role;
        }

        public void Delete(int id)
        {
            var role = GetById(id);
            _roles.Remove(role!);
        }
    }
}

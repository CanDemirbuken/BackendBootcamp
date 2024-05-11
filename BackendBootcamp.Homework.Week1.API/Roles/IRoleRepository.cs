namespace BackendBootcamp.Homework.Week1.API.Roles
{
    public interface IRoleRepository
    {
        IReadOnlyList<Role> GetAll();
        Role? GetById(int id);
        void Create(Role role);
        void Update(Role role);
        void Delete(int id);
    }
}

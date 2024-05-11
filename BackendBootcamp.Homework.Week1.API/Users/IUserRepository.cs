namespace BackendBootcamp.Homework.Week1.API.Users
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetAll();
        User? GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}

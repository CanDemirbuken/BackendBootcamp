namespace BackendBootcamp.Homework.Week1.API.Users
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users =
        [
            new User{Id = 1, FirstName = "Can", LastName = "Demirbüken", Age = 26, RoleId = 1},
            new User{Id = 2, FirstName = "Ali", LastName = "Veli", Age = 34, RoleId = 2},
            new User{Id = 3, FirstName = "Hede", LastName = "Bidi", Age = 17, RoleId = 3},
        ];

        public void Create(User user) => _users.Add(user);
        public IReadOnlyList<User> GetAll() => _users;
        public User? GetById(int id) => _users.Find(u => u.Id == id);

        public void Update(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            _users[index] = user;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _users.Remove(user!);
        }
    }
}

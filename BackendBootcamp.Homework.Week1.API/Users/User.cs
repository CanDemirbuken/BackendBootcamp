using BackendBootcamp.Homework.Week1.API.Roles;

namespace BackendBootcamp.Homework.Week1.API.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}

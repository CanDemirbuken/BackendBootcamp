using BackendBootcamp.Homework.Week1.API.Users;

namespace BackendBootcamp.Homework.Week1.API.Roles
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public virtual ICollection<User>? Users { get; set; }
    }
}

namespace BackendBootcamp.Homework.Week1.API.Users
{
    public class BirthYearCalculator
    {
        public int GetBirthYear(int age) => DateTime.Now.Year - age;
    }
}

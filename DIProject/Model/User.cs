
namespace DIProject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}

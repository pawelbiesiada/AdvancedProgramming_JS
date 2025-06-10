namespace MyWebApiServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public string Email { get; set; }
        public bool isActive { get; set; }
    }

    //Automapper

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }

        public UserDto(User user) 
        {
            Id = user.Id;
            Name = user.Name;
            isActive = user.isActive;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models.DTO
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginDTO(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}

using ToDoApplication.Models.DTO;

namespace ToDoApplication.Services.Interfaces
{
    public interface IRegisterService
    {
        public Task<bool> RegisterEmployee(UserDTO userDTO);
    }
}

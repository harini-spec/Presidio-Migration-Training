using ToDoApplication.Models;
using ToDoApplication.Models.DTO;
using ToDoApplication.Repositories;
using ToDoApplication.Services.Interfaces;

namespace ToDoApplication.Services.Classes
{
    public class RegisterService : IRegisterService
    {
        private readonly IRepository<int, User> _UserRepository;

        public RegisterService(IRepository<int, User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<bool> RegisterEmployee(UserDTO userDTO)
        {
            try
            {
                User user = new User();
                user.FirstName = userDTO.FirstName;
                user.LastName = userDTO.LastName;
                user.UserName = userDTO.UserName;
                user.Password = userDTO.Password;
                await _UserRepository.Add(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

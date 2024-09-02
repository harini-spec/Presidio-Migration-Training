using ToDoApplication.Models;
using ToDoApplication.Models.DTO;
using ToDoApplication.Repositories;
using ToDoApplication.Services.Interfaces;

namespace ToDoApplication.Services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, User> _UserRepository;

        public LoginService(IRepository<int, User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<bool> Authenticate(LoginDTO Creds)
        {
            try
            {
                var user = await _UserRepository.GetAll();
                if (user.Count == 0)
                {
                    return false;
                }
                var result = user.ToList().SingleOrDefault(u => u.UserName == Creds.UserName && u.Password == Creds.Password);
                if (result == null)
                    return false;
                else return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

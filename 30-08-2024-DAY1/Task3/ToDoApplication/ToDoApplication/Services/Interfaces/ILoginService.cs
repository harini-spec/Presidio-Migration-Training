using ToDoApplication.Models.DTO;

namespace ToDoApplication.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<bool> Authenticate(LoginDTO Creds);
    }
}

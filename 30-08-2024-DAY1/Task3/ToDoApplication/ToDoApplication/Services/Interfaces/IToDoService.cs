using ToDoApplication.Models;
using ToDoApplication.Models.DTO;

namespace ToDoApplication.Services.Interfaces
{
    public interface IToDoService
    {
        public Task<bool> InsertToDo(ToDoDTO toDoDTO);
        public Task<ToDo> SelectToDoById(int TodoId);
        public Task<List<ToDo>> SelectAllToDosOfUser(int UserId);
        public Task<bool> DeleteToDoById(int ToDoId);
        public Task<bool> UpdateToDo(UpdateToDoDTO todo);
    }
}

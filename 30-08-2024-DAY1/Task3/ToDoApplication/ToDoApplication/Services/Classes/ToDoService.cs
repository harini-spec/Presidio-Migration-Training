using ToDoApplication.Exceptions;
using ToDoApplication.Models;
using ToDoApplication.Models.DTO;
using ToDoApplication.Repositories;
using ToDoApplication.Services.Interfaces;

namespace ToDoApplication.Services.Classes
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<int, ToDo> _ToDoRepository;

        public ToDoService(IRepository<int, ToDo> toDoRepository)
        {
            _ToDoRepository = toDoRepository;
        }

        public async Task<bool> DeleteToDoById(int ToDoId)
        {
            try
            {
                var task = await _ToDoRepository.GetById(ToDoId);
                await _ToDoRepository.Delete(ToDoId);
                return true;
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Task not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertToDo(ToDoDTO toDoDTO)
        {
            try
            {
                ToDo toDo = new ToDo();
                toDo.UserId = toDoDTO.UserId;
                toDo.Title = toDoDTO.Title;
                toDo.Description = toDoDTO.Description;
                toDo.TargetDate = toDoDTO.TargetDate;
                toDo.Status = toDoDTO.Status;
                await _ToDoRepository.Add(toDo);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ToDo>> SelectAllToDosOfUser(int UserId)
        {
            try
            {
                var todos = await _ToDoRepository.GetAll();
                if (todos.Count == 0)
                    throw new EntityNotFoundException("No Tasks found!");
                var result = todos.ToList().FindAll(x => x.UserId == UserId);
                if (result.Count == 0)
                    throw new EntityNotFoundException("No Tasks found!");
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<ToDo> SelectToDoById(int TodoId)
        {
            try
            {
                var toDo = await _ToDoRepository.GetById(TodoId);
                return toDo;
            }
            catch(EntityNotFoundException)
            {
                throw new EntityNotFoundException("Task not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateToDo(UpdateToDoDTO todo)
        {
            try
            {
                var task_to_update = await SelectToDoById(todo.Id);
                task_to_update.Title = todo.Title;
                task_to_update.Description = todo.Description;
                task_to_update.TargetDate = todo.TargetDate;
                task_to_update.Status = todo.Status;
                await _ToDoRepository.Update(task_to_update);
                return true;
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException("Task not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using ToDoApplication.Models;

namespace ToDoApplication.Repositories
{
    public class ToDoRepository : AbstractRepository<int, ToDo>
    {
        public ToDoRepository(TaskContext context) : base(context)
        {
        }
    }
}

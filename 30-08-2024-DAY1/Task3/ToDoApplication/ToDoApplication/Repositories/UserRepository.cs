using ToDoApplication.Models;

namespace ToDoApplication.Repositories
{
    public class UserRepository : AbstractRepository<int, User>
    {
        public UserRepository(TaskContext context) : base(context)
        {
        }
    }
}

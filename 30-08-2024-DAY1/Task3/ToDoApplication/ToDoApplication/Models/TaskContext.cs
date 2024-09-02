using Microsoft.EntityFrameworkCore;
namespace ToDoApplication.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
    }
}

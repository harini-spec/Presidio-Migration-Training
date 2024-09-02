using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApplication.Models.DTO
{
    public class ToDoDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToDoApplication.Models;

namespace ToDoApplication.Models
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User TaskOfUser { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; }

        // Parameterless constructor for Entity Framework
        public ToDo()
        {
        }

        // Constructor with all parameters
        public ToDo(int id, string title, int userId, string description, DateTime targetDate, bool status)
        {
            Id = id;
            Title = title;
            UserId = userId;
            Description = description;
            TargetDate = targetDate;
            Status = status;
        }

        // Constructor without the id parameter, for creating new todos
        public ToDo(string title, int userId, string description, DateTime targetDate, bool status)
        {
            Title = title;
            UserId = userId;
            Description = description;
            TargetDate = targetDate;
            Status = status;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            ToDo other = (ToDo)obj;
            return Id == other.Id;
        }
    }
}

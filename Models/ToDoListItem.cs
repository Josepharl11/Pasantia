using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ToDoListItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Taskstate State { get; set; }
    }

    public enum Taskstate
    {
        pending = 0,
        completed = 1,
        cancelled = 2
    }
}

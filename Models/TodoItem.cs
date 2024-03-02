using System.ComponentModel.DataAnnotations;

namespace TodoAppServer.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        [MinLength(10)]
        public string? Name { get; set; }

        public DateTime? EndAt { get; set; }


        public TodoItemStatus? Status { get; set; }
    }

    public enum TodoItemStatus
    {
        Active,
        Completed,
    }
}

using TodoAppServer.Data;
using TodoAppServer.Models;

namespace TodoAppServer.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoAppServerContext _context;

        public TodoItemRepository(TodoAppServerContext context)
        {
            _context = context;
        }

        public TodoItem? GetTodoById(int id)
        {
            return _context.TodoItems.Find(id);
        }

        public IEnumerable<TodoItem> GetAllTodos()
        {
            return _context.TodoItems.ToList();
        }

        public TodoItem InsertTodo(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return item;
        }

        public void UpdateTodo(TodoItem item)
        {
            var existingItem = _context.TodoItems.Find(item.Id);
            if (existingItem != null)
            {
                existingItem.Status = item.Status == TodoItemStatus.Active ? TodoItemStatus.Completed : TodoItemStatus.Active;
                _context.SaveChanges();
            }
        }

        public void DeleteTodo(int todoId)
        {
            var todoToDelete = _context.TodoItems.Find(todoId);
            if (todoToDelete != null)
            {
                _context.TodoItems.Remove(todoToDelete);
                _context.SaveChanges();
            }
        }
    }
}
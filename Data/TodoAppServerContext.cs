using Microsoft.EntityFrameworkCore;
using TodoAppServer.Models;

namespace TodoAppServer.Data
{
    public class TodoAppServerContext : DbContext
    {
        public TodoAppServerContext(DbContextOptions<TodoAppServerContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoItem>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TodoItem>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TodoItem>().Property(t => t.EndAt).HasMaxLength(500);
            modelBuilder.Entity<TodoItem>().Property(t => t.Status).HasDefaultValue(TodoItemStatus.Active);
        }
    }
}

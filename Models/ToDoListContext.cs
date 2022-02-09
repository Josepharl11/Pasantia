using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions <ToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDoListItem> ToDoListItem { get; set; }
    }
}
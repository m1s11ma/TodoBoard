using Microsoft.EntityFrameworkCore;
using TodoBoardCore.Data.Entities;
using TodoBoardInfrastructure.DataAccess.Configurations.TodoItems;

namespace TodoBoardInfrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoItemComment> TodoItemComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemConfiguration());
        }
    }
}

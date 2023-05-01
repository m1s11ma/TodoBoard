using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.ValueObjects;

namespace TodoBoardInfrastructure.DataAccess.Configurations.TodoItems
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(item => item.Category).HasConversion(
                v => v.ToString(),
                v => TodoItemCategory.From(v)).IsRequired();
            builder.Property(item => item.Colour).HasConversion(
                v => v.ToString(),
                v => TodoItemColour.From(v)).IsRequired();
            builder.HasIndex(item => new { item.Title, item.Category}).IsUnique();
            builder.HasMany(item => item.Comments).WithOne(comment => comment.TodoItem).HasForeignKey(comment => comment.TodoItemId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

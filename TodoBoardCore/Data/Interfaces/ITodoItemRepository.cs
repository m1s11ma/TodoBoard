using System.Globalization;
using TodoBoardCore.Data.Entities;

namespace TodoBoardCore.Data.Interfaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<List<TodoItem>> GetAllWithCommentsAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task<TodoItem> GetByIdWithCommentsAsync(int id);
        Task<TodoItem> GetByTitleAsync(string title, string category);
        Task<TodoItem> GetByTitleWithCommentsAsync(string title, string category);
        Task<bool> IsExisteAsync(int id);
    }
}

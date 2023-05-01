using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IGetTodoItemService
    {
        Task<ResultWithData<TodoItemDto>> GetTodoItemAsync(string title, string category);
        Task<ResultWithData<TodoItemDto>> GetTodoItemAsync(int id);
    }
}

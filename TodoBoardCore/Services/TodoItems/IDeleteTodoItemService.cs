using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IDeleteTodoItemService
    {
        Task<ResultWithData<TodoItemDto>> DeleteTodoItemAsync(string title, string category);
        Task<ResultWithData<TodoItemDto>> DeleteTodoItemAsync(int id);
    }
}

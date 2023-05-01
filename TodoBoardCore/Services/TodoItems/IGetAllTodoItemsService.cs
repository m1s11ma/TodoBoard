using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IGetAllTodoItemsService
    {
        Task<ResultWithData<List<TodoItemDto>>> GetAllTodoItemsAsync();
    }
}

using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IAddTodoItemService
    {
        Task<Result> AddTodoItemAsync(AddTodoItemDto addTodoItemDto);
    }
}

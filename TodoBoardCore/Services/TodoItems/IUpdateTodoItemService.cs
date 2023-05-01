using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IUpdateTodoItemService
    {
        Task<ResultWithData<TodoItemDto>> UpdateTodoItemTitleAsync(int todoItemId, UpdateTodoItemTitleDto updateTodoItemTitleDto); 
    }
}

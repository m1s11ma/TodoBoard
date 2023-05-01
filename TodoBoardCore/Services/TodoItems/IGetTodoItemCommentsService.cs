using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IGetTodoItemCommentsService
    {
        Task<ResultWithData<List<TodoItemCommentDto>>> GetCommentsAsync(int todoItemId);
        Task<ResultWithData<List<TodoItemCommentDto>>> GetCommentsAsync(string todoItemTitle, string category);
    }
}

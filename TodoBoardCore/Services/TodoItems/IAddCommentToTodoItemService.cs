using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardCore.Services.TodoItems
{
    public interface IAddCommentToTodoItemService
    {
        Task<Result> AddCommentToTodoItem(int id, AddCommentToTodoItemDto addCommentToTodoItemDto);
        Task<Result> AddCommentToTodoItem(string title, string category, AddCommentToTodoItemDto addCommentToTodoItemDto);
    }
}

using AutoMapper;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class GetTodoItemCommentsService : BaseTodoItemService, IGetTodoItemCommentsService
    {
        public GetTodoItemCommentsService(ITodoItemRepository todoItemRepository, IMapper mapper) : base(todoItemRepository, mapper)
        {
        }
        public async Task<ResultWithData<List<TodoItemCommentDto>>> GetCommentsAsync(int todoItemId)
        {
            var todoItem = await GetTodoItem(todoItemId);
            if (!todoItem.Success) return ResultWithData<List<TodoItemCommentDto>>.FailedNotFound(todoItem.Message);
            return ResultWithData<List<TodoItemCommentDto>>.SuccessResult(todoItem.Data.Comments);
        }

        public async Task<ResultWithData<List<TodoItemCommentDto>>> GetCommentsAsync(string todoItemTitle, string category)
        {
            var todoItem = await GetTodoItem(todoItemTitle, category);
            if(!todoItem.Success) return ResultWithData<List<TodoItemCommentDto>>.FailedNotFound(todoItem.Message);
            return ResultWithData<List<TodoItemCommentDto>>.SuccessResult(todoItem.Data.Comments);
        }
    }
}

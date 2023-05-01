using AutoMapper;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class GetTodoItemService : BaseTodoItemService, IGetTodoItemService
    {
        public GetTodoItemService(ITodoItemRepository todoItemRepository, IMapper mapper) : base(todoItemRepository, mapper) { }

        public Task<ResultWithData<TodoItemDto>> GetTodoItemAsync(string title, string category)
        {
            return GetTodoItem(title, category);
        }

        public Task<ResultWithData<TodoItemDto>> GetTodoItemAsync(int id)
        {
            return GetTodoItem(id);
        }
    }
}

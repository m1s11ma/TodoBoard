using AutoMapper;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.Exceptions.TodoItems;
using TodoBoardCore.OperationResults;

namespace TodoBoardApplication.Services.TodoItems
{
    public abstract class BaseTodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;
        public BaseTodoItemService(ITodoItemRepository todoItemRepository, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }
        protected async Task<ResultWithData<TodoItemDto>> GetTodoItem(int todoItemId)
        {
            TodoItem todoItem;
            try
            {
                todoItem = await _todoItemRepository.GetByIdWithCommentsAsync(todoItemId);
            }
            catch (TodoItemNotFoundException ex)
            {
                return ResultWithData<TodoItemDto>.FailedNotFound(ex.Message);
            }
            return ResultWithData<TodoItemDto>.SuccessResult(_mapper.Map<TodoItemDto>(todoItem));
        }

        protected async Task<ResultWithData<TodoItemDto>> GetTodoItem(string title, string category)
        {
            TodoItem todoItem;
            try
            {
                todoItem = await _todoItemRepository.GetByTitleWithCommentsAsync(title, category);
            }
            catch (TodoItemNotFoundException ex)
            {
                return ResultWithData<TodoItemDto>.FailedNotFound(ex.Message);
            }
            return ResultWithData<TodoItemDto>.SuccessResult(_mapper.Map<TodoItemDto>(todoItem));
        }
    }
}

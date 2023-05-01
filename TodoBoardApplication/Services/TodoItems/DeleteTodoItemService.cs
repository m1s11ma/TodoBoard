using AutoMapper;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.Exceptions;
using TodoBoardCore.Exceptions.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class DeleteTodoItemService : IDeleteTodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteTodoItemService(ITodoItemRepository todoItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultWithData<TodoItemDto>> DeleteTodoItemAsync(string title, string category)
        {
            TodoItem todoItem;
            try
            {
                todoItem = await _todoItemRepository.GetByTitleAsync(title, category);
            }
            catch(TodoItemNotFoundException ex)
            {
                return ResultWithData<TodoItemDto>.FailedNotFound(ex.Message);
            }
            _todoItemRepository.Delete(todoItem);
            await _unitOfWork.SaveChangesAsync();
            return ResultWithData<TodoItemDto>.SuccessResult(_mapper.Map<TodoItemDto>(todoItem));
        }

        public async Task<ResultWithData<TodoItemDto>> DeleteTodoItemAsync(int id)
        {
            TodoItem todoItem;
            try
            {
                todoItem = await _todoItemRepository.GetByIdAsync(id);
            }
            catch (EntityNotFoundException<TodoItem> ex)
            {
                return ResultWithData<TodoItemDto>.FailedNotFound(ex.Message);
            }
            _todoItemRepository.Delete(todoItem);
            await _unitOfWork.SaveChangesAsync();
            return ResultWithData<TodoItemDto>.SuccessResult(_mapper.Map<TodoItemDto>(todoItem));
        }
    }
}

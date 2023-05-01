using AutoMapper;
using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.Exceptions;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class UpdateTodoItemService : IUpdateTodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTodoItemService(ITodoItemRepository todoItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _todoItemRepository = todoItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ResultWithData<TodoItemDto>> UpdateTodoItemTitleAsync(int todoItemId, UpdateTodoItemTitleDto updateTodoItemTitleDto)
        {
            TodoItem todoItem;
            try
            {
                todoItem = await _todoItemRepository.GetByIdAsync(todoItemId);
            }
            catch (EntityNotFoundException<TodoItem> ex)
            {
                return ResultWithData<TodoItemDto>.FailedNotFound(ex.Message);
            }

            todoItem.UpdateTitle(updateTodoItemTitleDto.Title);
            _todoItemRepository.Update(todoItem);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (ValueAlreadyExistException)
            {
                return ResultWithData<TodoItemDto>.FailedNonUnique("This title already exisits");
            }
            return ResultWithData<TodoItemDto>.SuccessResult(_mapper.Map<TodoItemDto>(todoItem));
        }
    }
}

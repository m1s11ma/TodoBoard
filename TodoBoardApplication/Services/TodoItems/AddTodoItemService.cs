using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.Data.ValueObjects;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.Exceptions;
using TodoBoardCore.Exceptions.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class AddTodoItemService : IAddTodoItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITodoItemRepository _todoItemRepository;

        public AddTodoItemService(IUnitOfWork unitOfWork, ITodoItemRepository todoItemRepository)
        {
            _unitOfWork = unitOfWork;
            _todoItemRepository = todoItemRepository;
        }

        public async Task<Result> AddTodoItemAsync(AddTodoItemDto addTodoItemDto)
        {
            TodoItemColour colour;
            TodoItemCategory category;
            try
            {
                colour = TodoItemColour.From(addTodoItemDto.Colour);
                category = TodoItemCategory.From(addTodoItemDto.Category);
            }
            catch(Exception ex) when(ex is UnsupportedCategoryException ||
                                     ex is UnsupportedColourException)
            {
                return Result.FailedBadArguments(ex.Message);
            }

            var todoItem = new TodoItem(addTodoItemDto.Title, category, colour);
            _todoItemRepository.Add(todoItem);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (ValueAlreadyExistException)
            {
                return Result.FailedNonUnique("Title must be unique");
            }
            return Result.SuccessResult();
        }
    }
}

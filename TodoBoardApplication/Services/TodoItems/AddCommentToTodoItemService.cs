using TodoBoardCore.Data.Entities;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.Exceptions;
using TodoBoardCore.Exceptions.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class AddCommentToTodoItemService : IAddCommentToTodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly ITodoItemCommentRepository _todoItemCommentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCommentToTodoItemService(ITodoItemRepository todoItemRepository, 
            ITodoItemCommentRepository todoItemCommentRepository, IUnitOfWork unitOfWork)
        {
            _todoItemRepository = todoItemRepository;
            _todoItemCommentRepository = todoItemCommentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddCommentToTodoItem(int id, AddCommentToTodoItemDto addCommentToTodoItemDto)
        {
            TodoItem item;
            try
            {
                item = await _todoItemRepository.GetByIdWithCommentsAsync(id);
            }
            catch(EntityNotFoundException<TodoItem> ex)
            {
                return Result.FailedNotFound(ex.Message);
            }
            await AddCommentToTodoItem(item, addCommentToTodoItemDto);
            return Result.SuccessResult();
        }

        public async Task<Result> AddCommentToTodoItem(string title, string category, AddCommentToTodoItemDto addCommentToTodoItemDto)
        {
            TodoItem item;
            try
            {
                item = await _todoItemRepository.GetByTitleWithCommentsAsync(title, category);
            }
            catch(TodoItemNotFoundException ex)
            {
                return Result.FailedNotFound(ex.Message);
            }
            await AddCommentToTodoItem(item, addCommentToTodoItemDto);
            return Result.SuccessResult();
        }

        private async Task AddCommentToTodoItem(TodoItem todoItem, AddCommentToTodoItemDto addCommentToTodoItemDto)
        {
            var todoItemComment = todoItem.AddComment(addCommentToTodoItemDto.Comment);
            _todoItemCommentRepository.Add(todoItemComment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

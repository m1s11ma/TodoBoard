using AutoMapper;
using TodoBoardCore.Data.Interfaces;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardApplication.Services.TodoItems
{
    public class GetAllTodoItemsService : IGetAllTodoItemsService
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly IMapper _mapper;
        public GetAllTodoItemsService(ITodoItemRepository todoItemRepository, IMapper mapper) 
        {
            _todoItemRepository = todoItemRepository;
            _mapper = mapper;
        }
        public async Task<ResultWithData<List<TodoItemDto>>> GetAllTodoItemsAsync()
        {
            var items = await _todoItemRepository.GetAllWithCommentsAsync();
            var itemsDTOs = _mapper.Map<List<TodoItemDto>>(items);
            return ResultWithData<List<TodoItemDto>>.SuccessResult(itemsDTOs);
        }
    }
}

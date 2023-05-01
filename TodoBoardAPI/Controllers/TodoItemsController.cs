using Microsoft.AspNetCore.Mvc;
using TodoBoardCore.DTOs.TodoItems;
using TodoBoardCore.OperationResults;
using TodoBoardCore.Services.TodoItems;

namespace TodoBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IAddCommentToTodoItemService _addCommentToTodoItemService;
        private readonly IAddTodoItemService _addTodoItemService;
        private readonly IDeleteTodoItemService _deleteTodoItemService;
        private readonly IGetAllTodoItemsService _getAllTodoItemsService;
        private readonly IGetTodoItemCommentsService _getTodoItemCommentsService;
        private readonly IGetTodoItemService _getTodoItemService;
        private readonly IUpdateTodoItemService _updateTodoItemService;

        public TodoItemsController(IAddCommentToTodoItemService addCommentToTodoItemService, IAddTodoItemService addTodoItemService, 
            IDeleteTodoItemService deleteTodoItemService, IGetAllTodoItemsService getAllTodoItemsService, 
            IGetTodoItemCommentsService getTodoItemCommentsService, IGetTodoItemService getTodoItemService, 
            IUpdateTodoItemService updateTodoItemService)
        {
            _addCommentToTodoItemService = addCommentToTodoItemService;
            _addTodoItemService = addTodoItemService;
            _deleteTodoItemService = deleteTodoItemService;
            _getAllTodoItemsService = getAllTodoItemsService;
            _getTodoItemCommentsService = getTodoItemCommentsService;
            _getTodoItemService = getTodoItemService;
            _updateTodoItemService = updateTodoItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodoItems()
        {
            var result = await _getAllTodoItemsService.GetAllTodoItemsAsync();
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(int id)
        {
            var todoItem = await _getTodoItemService.GetTodoItemAsync(id);
            if (!todoItem.Success) return NotFound(todoItem.Message);
            return Ok(todoItem.Data);

        }

        [HttpGet("{id}/Comments")]
        public async Task<IActionResult> GetTodoItemComments(int id)
        {
            var comments = await _getTodoItemCommentsService.GetCommentsAsync(id);
            if (!comments.Success) return NotFound(comments.Message);
            return Ok(comments.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoItem([FromBody] AddTodoItemDto todoItem)
        {
            var result = await _addTodoItemService.AddTodoItemAsync(todoItem);
            if (!result.Success)
            {
                switch (result.FailureType)
                {
                    case FailedTypes.NotFound:
                        return NotFound(result.Message);
                    case FailedTypes.NonUnique:
                        return BadRequest(result.Message);
                    case FailedTypes.BadArguments:
                        return BadRequest(result.Message);
                }
            }
            return Ok();
        }

        [HttpPut("{id}/AddComment")]
        public async Task<IActionResult> AddCommentToTodoItem(int id, [FromBody]AddCommentToTodoItemDto addCommentToTodoItemDto)
        {
            var result = await _addCommentToTodoItemService.AddCommentToTodoItem(id, addCommentToTodoItemDto);
            if (!result.Success) return NotFound(result.Message);
            return Ok();
        }

        [HttpPut("{id}/UpdateTitle")]
        public async Task<IActionResult> UpdateTodoItemTitle(int id, [FromBody] UpdateTodoItemTitleDto updateTodoItemTitleDto)
        {
            var result = await _updateTodoItemService.UpdateTodoItemTitleAsync(id, updateTodoItemTitleDto);
            if (!result.Success)
            {
                switch (result.FailureType)
                {
                    case FailedTypes.NotFound:
                        return NotFound(result.Message);
                    case FailedTypes.NonUnique:
                        return BadRequest(result.Message);
                }
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var result = await _deleteTodoItemService.DeleteTodoItemAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok();
        }
    }
}

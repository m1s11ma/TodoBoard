using TodoBoardCore.Data.Common;

namespace TodoBoardCore.Data.Entities
{
    public class TodoItemComment : BaseEntity
    {
        public string Text { get; private set; }
        public int TodoItemId { get; private set; }
        public TodoItem TodoItem { get; init; }

        public TodoItemComment(string text, int todoItemId)
        {
            Text = text;
            TodoItemId = todoItemId;
        }
    }
}

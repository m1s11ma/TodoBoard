namespace TodoBoardCore.Exceptions.TodoItems
{
    public class TodoItemNotFoundException : Exception
    {
        public TodoItemNotFoundException(string title) : base($"Todo item with title {title} wasn't found") { }
    }
}

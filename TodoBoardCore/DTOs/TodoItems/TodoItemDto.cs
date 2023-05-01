namespace TodoBoardCore.DTOs.TodoItems
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set;  }
        public bool IsCompleted { get; set; }
        public string Category { get; set; }
        public string Colour { get; set; }
        public string MD5Hash { get; set; }
        public List<TodoItemCommentDto> Comments { get; set; } 
    }
}

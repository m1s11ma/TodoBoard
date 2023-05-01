using System.Security.Cryptography;
using System.Text;
using TodoBoardCore.Data.Common;
using TodoBoardCore.Data.ValueObjects;

namespace TodoBoardCore.Data.Entities
{
    public class TodoItem : AggregateRoot
    {
        public string Title { get; private set; }
        public DateTime CreateDate { get; init; }
        public bool IsCompleted { get; private set; }
        public TodoItemCategory  Category { get; private set; }
        public TodoItemColour Colour { get; private set; }

        private List<TodoItemComment> _comments { get; set; }
        public IReadOnlyCollection<TodoItemComment> Comments 
        { 
            get { return _comments; } 
            init { _comments = value.ToList(); } 
        }

        public TodoItem(string title, TodoItemCategory category, TodoItemColour colour, bool isCompleted = false)
        {
            Title = title;
            CreateDate = DateTime.UtcNow;
            IsCompleted = isCompleted;
            Category = category;
            Colour = colour;
        }

        public TodoItemComment AddComment(string commentText)
        {
            var comment = new TodoItemComment(commentText, Id);
            _comments.Add(comment);
            return comment;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public string GetMD5Hash()
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(Title);
            var hashBytes = md5.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}

using TodoBoardCore.Data.Common;
using TodoBoardCore.Exceptions.TodoItems;

namespace TodoBoardCore.Data.ValueObjects
{
    public sealed class TodoItemCategory : ValueObject
    {
        public string Category { get; init; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Category;
        }

        public override string ToString()
        {
            return Category;
        }
        private TodoItemCategory(string category)
        {
            Category = category;
        }

        public static TodoItemCategory From(string category)
        {
            var newCategory = new TodoItemCategory(category);
            if (!SupportedCategories.Contains(newCategory)) throw new UnsupportedCategoryException(category);
            return newCategory;
        }

        public static TodoItemCategory BookKeeping => new("BookKeeping");
        public static TodoItemCategory Marketing => new("Marketing");
        public static TodoItemCategory Analytics => new("Analytics");

        protected static IEnumerable<TodoItemCategory> SupportedCategories { get
            {
                yield return BookKeeping;
                yield return Marketing;
                yield return Analytics;
            } }

    }
}

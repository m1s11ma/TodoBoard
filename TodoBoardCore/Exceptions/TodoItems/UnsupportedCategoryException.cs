namespace TodoBoardCore.Exceptions.TodoItems
{
    public class UnsupportedCategoryException : Exception
    {
        public UnsupportedCategoryException(string categoryName)
            : base($"Category {categoryName} is not presented in system")
        { }
    }
}

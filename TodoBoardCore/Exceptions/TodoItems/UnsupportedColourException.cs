namespace TodoBoardCore.Exceptions.TodoItems
{
    public class UnsupportedColourException : Exception
    {
        public UnsupportedColourException(string colour)
            : base($"Colour {colour} is not supported")
        { }
    }
}

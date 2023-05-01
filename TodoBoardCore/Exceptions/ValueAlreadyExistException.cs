namespace TodoBoardCore.Exceptions
{
    public class ValueAlreadyExistException : Exception
    {
        public ValueAlreadyExistException() : base($"Value already exists") { }
    }
}

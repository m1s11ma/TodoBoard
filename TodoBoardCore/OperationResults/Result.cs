namespace TodoBoardCore.OperationResults
{
    public class Result
    {
        public bool Success { get; init; }
        public string Message { get; init; }
        public FailedTypes FailureType { get; init; }
        protected Result()
        {
            Success = true;
        }

        protected Result(string message, FailedTypes failedType)
        {
            Success = false;
            Message = message;
            FailureType = failedType;
        }

        public static Result SuccessResult() => new();

        public static Result FailedResult(string message) => new(message, FailedTypes.Unknown);
        public static Result FailedNotFound(string message) => new(message, FailedTypes.NotFound);
        public static Result FailedNonUnique(string message) => new(message, FailedTypes.NonUnique);
        public static Result FailedBadArguments(string message) => new(message, FailedTypes.BadArguments);
    }
}

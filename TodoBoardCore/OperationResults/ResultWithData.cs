namespace TodoBoardCore.OperationResults
{
    public class ResultWithData<TData>
    {
        public bool Success { get; init; }
        public TData Data { get; init; }
        public string Message { get; init; }
        public FailedTypes FailureType { get; init; }
        protected ResultWithData(TData data) 
        {
            Data = data;
            Success = true;
        }

        protected ResultWithData(string message, FailedTypes failedType)
        {
            Message = message;
            Success = false;
            FailureType = failedType;
        }

        public static ResultWithData<TData> SuccessResult(TData data) => new(data);
        public static ResultWithData<TData> FailedResult(string message) => new(message, FailedTypes.Unknown);
        public static ResultWithData<TData> FailedNotFound(string message) => new(message, FailedTypes.NotFound);
        public static ResultWithData<TData> FailedNonUnique(string message) => new(message, FailedTypes.NonUnique);
        public static ResultWithData<TData> FailedBadArguments(string message) => new(message, FailedTypes.BadArguments);
    }
}

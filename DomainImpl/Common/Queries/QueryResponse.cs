using DomainApi.Common.Queries;

namespace DomainImpl.Common.Queries;

internal static class QueryResponse
{
    internal static IQueryResponse Success()
    {
        return new SuccessResponse();
    }

    internal static IQueryResponse Error(string errorSummary)
    {
        return new ErrorResponse(errorSummary, new List<string>());
    }

    internal static IQueryResponse Error(string errorSummary, List<string> errorDetails)
    {
        return new ErrorResponse(errorSummary, errorDetails);
    }

    private class SuccessResponse : IQueryResponse
    {
        public bool IsSuccess => true;
        public string ErrorSummary => string.Empty;
        public List<string> ErrorDetails { get; } = new();
    }

    private class ErrorResponse(string errorSummary, List<string> errorDetails) : IQueryResponse
    {
        public bool IsSuccess => false;
        public string ErrorSummary { get; } = errorSummary;
        public List<string> ErrorDetails { get; } = errorDetails;
    }
}

internal static class QueryResponse<TResponse>
{
    internal static IQueryResponse<TResponse> Success(TResponse value)
    {
        return new SuccessResponse<TResponse>(value);
    }

    internal static IQueryResponse<TResponse?> Error(string errorSummary)
    {
        return new ErrorResponse<TResponse?>(errorSummary, new List<string>());
    }

    internal static IQueryResponse<TResponse?> Error(string errorSummary, List<string> errorDetails)
    {
        return new ErrorResponse<TResponse?>(errorSummary, errorDetails);
    }

    private class SuccessResponse<TSuccessResponse>(TSuccessResponse response) : IQueryResponse<TSuccessResponse>
    {
        public bool IsSuccess => true;
        public string ErrorSummary => string.Empty;
        public List<string> ErrorDetails { get; } = new();
        public TSuccessResponse Value { get; } = response;
    }

    private class ErrorResponse<TErrorResponse>(string errorSummary, List<string> errorDetails)
        : IQueryResponse<TErrorResponse>
    {
        public bool IsSuccess => false;
        public string ErrorSummary { get; } = errorSummary;
        public List<string> ErrorDetails { get; } = errorDetails;
        public TErrorResponse Value => default;
    }
}

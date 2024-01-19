using DomainApi.Common.Commands;

namespace DomainImpl.Common.Commands;

internal static class CommandResponse
{
    internal static ICommandResponse Success()
    {
        return new SuccessResponse();
    }

    internal static ICommandResponse Error(string errorSummary)
    {
        return new ErrorResponse(errorSummary, new List<string>());
    }

    internal static ICommandResponse Error(string errorSummary, List<string> errorDetails)
    {
        return new ErrorResponse(errorSummary, errorDetails);
    }

    private class SuccessResponse : ICommandResponse
    {
        public bool IsSuccess => true;
        public string ErrorSummary => string.Empty;
        public List<string> ErrorDetails { get; } = new();
    }

    private class ErrorResponse(string errorSummary, List<string> errorDetails) : ICommandResponse
    {
        public bool IsSuccess => false;
        public string ErrorSummary { get; } = errorSummary;
        public List<string> ErrorDetails { get; } = errorDetails;
    }
}

internal static class CommandResponse<TResponse>
{
    internal static ICommandResponse<TResponse> Success(TResponse value)
    {
        return new SuccessResponse<TResponse>(value);
    }

    internal static ICommandResponse<TResponse> Error(TResponse value, string errorSummary)
    {
        return new ErrorResponse<TResponse>(value, errorSummary, new List<string>());
    }

    internal static ICommandResponse<TResponse> Error(TResponse value, string errorSummary, List<string> errorDetails)
    {
        return new ErrorResponse<TResponse>(value, errorSummary, errorDetails);
    }

    private class SuccessResponse<TSuccessResponse>(TSuccessResponse response) : ICommandResponse<TSuccessResponse>
    {
        public bool IsSuccess => true;
        public string ErrorSummary => string.Empty;
        public List<string> ErrorDetails { get; } = new();
        public TSuccessResponse Value { get; } = response;
    }

    private class ErrorResponse<TErrorResponse>(TErrorResponse value, string errorSummary, List<string> errorDetails)
        : ICommandResponse<TErrorResponse>
    {
        public bool IsSuccess => false;
        public string ErrorSummary { get; } = errorSummary;
        public List<string> ErrorDetails { get; } = errorDetails;
        public TErrorResponse Value { get; } = value;
    }
}

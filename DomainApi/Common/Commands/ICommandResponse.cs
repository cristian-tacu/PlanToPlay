namespace DomainApi.Common.Commands;

public interface ICommandResponse
{
    public bool IsSuccess { get; }

    public string ErrorSummary { get; }

    public List<string> ErrorDetails { get; }
}

public interface ICommandResponse<out TResponse> : ICommandResponse
{
    public TResponse Value { get; }
}

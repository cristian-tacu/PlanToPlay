namespace DomainApi.Common.Queries;

public interface IQueryResponse
{
    public bool IsSuccess { get; }

    public string ErrorSummary { get; }

    public List<string> ErrorDetails { get; }
}

public interface IQueryResponse<out TResponse> : IQueryResponse
{
    public TResponse Value { get; }
}

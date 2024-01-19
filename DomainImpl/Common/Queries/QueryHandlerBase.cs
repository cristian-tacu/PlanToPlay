using DomainApi.Common.Queries;

namespace DomainImpl.Common.Queries;

public abstract class QueryHandlerBase<TQuery> : IQueryHandler<TQuery> where TQuery : IQuery
{
    protected IQueryResponse Success()
    {
        return QueryResponse.Success();
    }

    protected IQueryResponse Error(string errorSummary)
    {
        return QueryResponse.Error(errorSummary);
    }

    protected IQueryResponse Error(string errorSummary, List<string> errorDetails)
    {
        return QueryResponse.Error(errorSummary, errorDetails);
    }

    public abstract Task Handle(TQuery request, CancellationToken cancellationToken);
}

public abstract class QueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    protected IQueryResponse<TResponse> Success(TResponse value)
    {
        return QueryResponse<TResponse>.Success(value);
    }

    protected IQueryResponse<TResponse?> Error(string errorSummary)
    {
        return QueryResponse<TResponse>.Error(errorSummary);
    }

    protected IQueryResponse<TResponse?> Error(string errorSummary, List<string> errorDetails)
    {
        return QueryResponse<TResponse>.Error(errorSummary, errorDetails);
    }

    public abstract Task<IQueryResponse<TResponse>> Handle(TQuery request, CancellationToken cancellationToken);
}

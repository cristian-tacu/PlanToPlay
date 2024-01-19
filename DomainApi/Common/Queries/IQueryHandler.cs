using MediatR;

namespace DomainApi.Common.Queries;

public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery> where TQuery : IQuery;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, IQueryResponse<TResponse>>
    where TQuery : IQuery<TResponse>;

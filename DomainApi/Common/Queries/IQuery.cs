using MediatR;

namespace DomainApi.Common.Queries;

public interface IQuery : IRequest;

public interface IQuery<out TResponse> : IRequest<IQueryResponse<TResponse>>;

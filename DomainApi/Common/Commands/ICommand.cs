using DomainApi.Common.Queries;
using MediatR;

namespace DomainApi.Common.Commands;

public interface ICommand : IRequest<ICommandResponse>;

public interface ICommand<out TResponse> : IRequest<ICommandResponse<TResponse>>;

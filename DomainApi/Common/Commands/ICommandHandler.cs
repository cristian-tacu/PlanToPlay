using DomainApi.Common.Queries;
using MediatR;

namespace DomainApi.Common.Commands;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, ICommandResponse> where TCommand : ICommand, IRequest<ICommandResponse>;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, ICommandResponse<TResponse>> where TCommand : ICommand<TResponse>;

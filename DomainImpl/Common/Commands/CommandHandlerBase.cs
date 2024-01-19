using DomainApi.Common.Commands;

namespace DomainImpl.Common.Commands;

public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
{
    protected ICommandResponse Success()
    {
        return CommandResponse.Success();
    }

    protected ICommandResponse Error(string errorSummary)
    {
        return CommandResponse.Error(errorSummary);
    }

    protected ICommandResponse Error(string errorSummary, List<string> errorDetails)
    {
        return CommandResponse.Error(errorSummary, errorDetails);
    }

    public abstract Task<ICommandResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class CommandHandlerBase<TCommand, TResponse> : ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    protected ICommandResponse<TResponse> Success(TResponse value)
    {
        return CommandResponse<TResponse>.Success(value);
    }

    protected ICommandResponse<TResponse> Error(TResponse value, string errorSummary)
    {
        return CommandResponse<TResponse>.Error(value, errorSummary);
    }

    protected ICommandResponse<TResponse> Error(TResponse value, string errorSummary, List<string> errorDetails)
    {
        return CommandResponse<TResponse>.Error(value, errorSummary, errorDetails);
    }

    public abstract Task<ICommandResponse<TResponse>> Handle(TCommand request, CancellationToken cancellationToken);
}

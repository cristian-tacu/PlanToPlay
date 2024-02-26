using AutoMapper;
using DomainApi.Common.Commands;
using DomainApi.Common.Repositories;
using DomainApi.Players.Commands;
using DomainImpl.Common.Commands;

namespace DomainImpl.Players.Commands;

public class ChangeRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : CommandHandlerBase<ChangeRoleCommand>
{
    public override Task<ICommandResponse> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
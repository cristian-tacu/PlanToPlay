using AutoMapper;
using DomainApi.Common.Commands;
using DomainApi.Common.Repositories;
using DomainApi.Players.Commands;
using DomainApi.Players.Models;
using DomainImpl.Common.Commands;

namespace DomainImpl.Players.Commands;

public class PostPlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : CommandHandlerBase<PostPlayerCommand, string>
{
    public override async Task<ICommandResponse<string>> Handle(PostPlayerCommand request, CancellationToken cancellationToken)
    {
        var checkPlayer = await unitOfWork.Players.GetPlayerByEmail(request.Player.Email);

        if (checkPlayer != null)
        {
            return Error(null!, "401", ["Player already exist"]);
        } 
        
        var player = mapper.Map<PlayerModel>(request);

        await unitOfWork.Players.Add(player);
        await unitOfWork.Complete();

        return Success(player.Id);
    }
}
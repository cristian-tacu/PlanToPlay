using AutoMapper;
using DomainApi.Common.Commands;
using DomainApi.Common.Repositories;
using DomainApi.Players.Commands;
using DomainApi.Players.Models;
using DomainImpl.Common.Commands;

namespace DomainImpl.Players.Commands;

public class JoinRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : CommandHandlerBase<JoinRoomCommand>
{
    public override async Task<ICommandResponse> Handle(JoinRoomCommand request, CancellationToken cancellationToken)
    {
        var checkPlayer = await unitOfWork.PlayerRooms.GetPlayerRoomEntry(request.PlayerId, request.RoomId);

        if (checkPlayer != null)
        {
            return Error("401", ["Player already exist in this room"]);
        } 
        
        var playerRoom = mapper.Map<PlayerRoomModel>(request);
        
        await unitOfWork.PlayerRooms.Add(playerRoom);
        await unitOfWork.Stats.Add(new StatsModel
            { PlayerRoomId = playerRoom.Id, LastWeek = 8, Last2Weeks = 8, Last3Weeks = 8 });
        await unitOfWork.Complete();
        
        return Success();
    }
}
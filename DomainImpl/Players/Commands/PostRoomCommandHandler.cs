using AutoMapper;
using DomainApi.Common.Commands;
using DomainApi.Common.Repositories;
using DomainApi.Players.Commands;
using DomainApi.Players.Models;
using DomainImpl.Common.Commands;

namespace DomainImpl.Players.Commands;

public class PostRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : CommandHandlerBase<PostRoomCommand, string>
{
    public override async Task<ICommandResponse<string>> Handle(PostRoomCommand request, CancellationToken cancellationToken)
    {
        var room = mapper.Map<RoomModel>(request.Room);
        var roomKey = room.Id;
        var playerRoom = mapper.Map<PlayerRoomModel>(request.Room);
        playerRoom.RoomId = roomKey;
        
        await unitOfWork.Rooms.Add(room);
        await unitOfWork.PlayerRooms.Add(playerRoom);
        await unitOfWork.Stats.Add(new StatsModel
            { PlayerRoomId = playerRoom.Id, LastWeek = 8, Last2Weeks = 8, Last3Weeks = 8 });
        await unitOfWork.Complete();

        return Success(roomKey);
    }
}
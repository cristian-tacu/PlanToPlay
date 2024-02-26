using AutoMapper;
using DomainApi.Common.Commands;
using DomainApi.Common.Repositories;
using DomainApi.Players.Commands;
using DomainImpl.Common.Commands;

namespace DomainImpl.Players.Commands;

public class DeletePlayerFromRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : CommandHandlerBase<DeletePlayerFromRoomCommand>
{
    public override async Task<ICommandResponse> Handle(DeletePlayerFromRoomCommand request, CancellationToken cancellationToken)
    {
        var checkPlayer = await unitOfWork.PlayerRooms.GetPlayerRoomEntry(request.PlayerId, request.RoomId);

        if (checkPlayer == null)
        {
            return Error("404", ["Player does not exist"]);
        }

        await unitOfWork.PlayerRooms.Delete(checkPlayer);
        await unitOfWork.Complete();

        return Success();
    }
}
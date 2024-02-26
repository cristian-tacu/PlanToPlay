using AutoMapper;
using DomainApi.Common.Commands;
using DomainApi.Common.Repositories;
using DomainApi.Players.Commands;
using DomainApi.Players.Models;
using DomainImpl.Common.Commands;
using DomainImpl.Players.Commands.Helpers;

namespace DomainImpl.Players.Commands;

public class UploadGradeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : CommandHandlerWithPlayerValidation<UploadGradeCommand>
{
    public override async Task<ICommandResponse> Handle(UploadGradeCommand request, CancellationToken cancellationToken)
    {
        var player = await unitOfWork.Players.GetAsync(request.PlayerId);
        var room = await  unitOfWork.Rooms.GetRoomWithPlayers(request.RoomId);
        var evaluatorPlayer = await unitOfWork.Players.GetAsync(request.EvaluatorPlayerId);
        var playerRoom = await unitOfWork.PlayerRooms.GetPlayerRoomEntry(request.PlayerId, request.RoomId);
        var evaluatorPlayerRoom =
            await unitOfWork.PlayerRooms.GetPlayerRoomEntry(request.EvaluatorPlayerId, request.RoomId);

        var checkResult = CheckPlayer(player, room, playerRoom);

        if (checkResult != null)
        {
            return checkResult;
        }
        
        var checkResultForGradedPlayer = CheckPlayer(evaluatorPlayer, room, evaluatorPlayerRoom);

        if (checkResultForGradedPlayer != null)
        {
            return checkResultForGradedPlayer;
        }

        if (!playerRoom!.IsPlaying)
        {
            return Error("400", ["This player cannot be graded because was not present last time"]);
        }
        
        if (!evaluatorPlayerRoom!.IsPlaying)
        {
            return Error("400", ["You cannot evaluate because you were not present last time"]);
        }

        await unitOfWork.Grades.Add(new GradeModel
        {
            EvaluatorPlayerId = request.EvaluatorPlayerId,
            Grade = request.Grade,
            PlayerRoomId = playerRoom.Id
        });
        await unitOfWork.Complete();

        return Success();
    }
}
using DomainApi.Common.Commands;
using DomainApi.Players.Models;
using DomainImpl.Common.Commands;

namespace DomainImpl.Players.Commands.Helpers;

public abstract class CommandHandlerWithPlayerValidation<TCommand> : CommandHandlerBase<TCommand>
    where TCommand : ICommand
{
    public ICommandResponse? CheckPlayer(PlayerModel? player, RoomModel? room, PlayerRoomModel? playerRoom)
    {
        if (room == null)
        {
            return Error("404", ["Room does not exist"]);
        }
        
        if (player == null)
        {
            return Error("404", ["Player does not exist"]);
        }

        if (playerRoom == null)
        {
            return Error("400", ["Player does not belong to this room"]);
        }
        
        return null;
    }
}

public abstract class CommandHandlerWithPlayerValidation<TCommand, TResponse> : CommandHandlerBase<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    public ICommandResponse? CheckPlayer(PlayerModel? player, RoomModel? room, PlayerRoomModel? playerRoom)
    {
        if (room == null)
        {
            return Error(default!, "404", ["Room does not exist"]);
        }
        
        if (player == null)
        {
            return Error(default!, "404", ["Player does not exist"]);
        }

        if (playerRoom == null)
        {
            return Error(default!,"400", ["Player does not belong to this room"]);
        }
        
        return null;
    }
}
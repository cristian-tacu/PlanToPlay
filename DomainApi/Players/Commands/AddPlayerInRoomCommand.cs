using DomainApi.Players.Enums;
using ICommand = DomainApi.Common.Commands.ICommand;

namespace DomainApi.Players.Commands;

public class AddPlayerInRoomCommand(string roomId, string playerId) : ICommand
{
    public string RoomId { get; } = roomId;
    public string PlayerId { get; } = playerId;
    public static RoomRole RoomRole => RoomRole.Player;
}
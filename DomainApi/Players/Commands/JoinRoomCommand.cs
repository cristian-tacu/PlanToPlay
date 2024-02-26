using DomainApi.Common.Commands;

namespace DomainApi.Players.Commands;

public class JoinRoomCommand(string roomId, string playerId) : ICommand
{
    public string RoomId { get; } = roomId;
    public string PlayerId { get; } = playerId;
}
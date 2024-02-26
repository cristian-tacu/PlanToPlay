namespace DomainApi.Players.Commands;

public class PlayerRoomCommand(string roomId, string playerId)
{
    public string RoomId { get; } = roomId;
    public string PlayerId { get; } = playerId;
}
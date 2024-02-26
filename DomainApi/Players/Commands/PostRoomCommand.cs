using DomainApi.Common.Commands;
using DomainApi.Players.Dtos;
using DomainApi.Players.Enums;

namespace DomainApi.Players.Commands;

public class PostRoomCommand(RoomDto request, string playerId) : ICommand<string>
{
    public RoomDto Room { get; } = request;
    public string PlayerId { get; } = playerId;
    public RoomRole RoomRole => RoomRole.Admin;
}
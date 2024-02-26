using KsuidDotNet;
namespace DomainApi.Players.Models;

public class RoomModel
{
    public string Id { get; init; } = Ksuid.NewKsuid();
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    
    public ICollection<PlayerRoomModel> PlayerRooms { get; init; }
}
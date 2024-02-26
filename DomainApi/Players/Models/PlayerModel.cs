namespace DomainApi.Players.Models;

public class PlayerModel
{
    public string Id { get; init; } = KsuidDotNet.Ksuid.NewKsuid();
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
    public double Grade { get; init; }
    
    public ICollection<PlayerRoomModel> PlayerRooms { get; init; }
}
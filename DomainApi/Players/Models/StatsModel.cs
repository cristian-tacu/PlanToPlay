namespace DomainApi.Players.Models;

public class StatsModel
{
    public string Id { get; init; } = KsuidDotNet.Ksuid.NewKsuid();
    
    public string PlayerRoomId { get; init; }
    public double LastWeek { get; init; }
    public double Last2Weeks { get; init; }
    public double Last3Weeks { get; init; }
    
    public virtual PlayerRoomModel PlayerRoom { get; init; }
}
namespace DomainApi.Players.Models;

public class GradeModel
{
    public string Id { get; init; } = KsuidDotNet.Ksuid.NewKsuid();
    public string EvaluatorPlayerId { get; init; } = null!;
    public string PlayerRoomId { get; init; } = null!;
    public double Grade { get; init; }
    public DateTime Date { get; init; } = DateTime.Now;
    
    public PlayerRoomModel PlayerRoom { get; init; } = null!;
}
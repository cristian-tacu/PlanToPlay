using DomainApi.Players.Enums;

namespace DomainApi.Players.Models;

public class PlayerRoomModel
{
    public string Id { get; init; } = KsuidDotNet.Ksuid.NewKsuid();
    public string PlayerId { get; init; } = null!;
    public string RoomId { get; set; } = null!;

    public RoomRole Role { get; }
    public bool IsPlaying => false;

    public virtual StatsModel Stats { get; init; } = null!;
    public virtual PlayerModel Player { get; init; } = null!;
    public virtual RoomModel Room { get; init; } = null!;
    public List<GradeModel> Grades { get; init; } = null!;
}
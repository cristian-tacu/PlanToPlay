using DomainApi.Common.Commands;

namespace DomainApi.Players.Commands;

public class UploadGradeCommand(string roomId, string playerId, string gradedPlayerId, double grade) : ICommand
{
    public string RoomId { get; } = roomId;
    public string PlayerId { get; } = playerId;
    public string EvaluatorPlayerId { get; } = gradedPlayerId;
    public double Grade { get; } = grade;
}
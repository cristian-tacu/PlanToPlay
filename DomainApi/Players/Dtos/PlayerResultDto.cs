namespace DomainApi.Players.Dtos;

public class PlayerResultDto
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string StatsId { get; init; } = null!;
    public double Grade { get; init; }
}
namespace DomainApi.Players.Dtos;

public class PlayerAddDto : PlayerDto
{
    public string Password { get; init; } = null!;
    public string Email { get; init; } = null!;
}
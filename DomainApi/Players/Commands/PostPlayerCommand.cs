using DomainApi.Common.Commands;
using DomainApi.Players.Dtos;

namespace DomainApi.Players.Commands;

public class PostPlayerCommand(PlayerAddDto request) : ICommand<string>
{
    public PlayerAddDto Player { get; } = request;
}
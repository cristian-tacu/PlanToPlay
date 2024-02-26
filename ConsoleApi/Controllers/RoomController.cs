using Asp.Versioning;
using DomainApi.Players.Commands;
using DomainApi.Players.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApi.Controllers;

[ApiVersion(1.0)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class RoomController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RoomResultDto>>> GetAll(
        [FromHeader] string playerId,
        [FromBody] RoomDto request,
        CancellationToken cancellationToken
    )
    {
        var result =
            await sender.Send(new PostRoomCommand(request, playerId), cancellationToken);

        return Ok(result.Value);
    }
}
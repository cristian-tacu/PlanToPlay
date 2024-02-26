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
public class PlayerController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> Post(
        [FromBody] PlayerAddDto request,
        CancellationToken cancellationToken
    )
    {
        var result =
            await sender.Send(new PostPlayerCommand(request), cancellationToken);

        return Ok(result.Value);
    }
}
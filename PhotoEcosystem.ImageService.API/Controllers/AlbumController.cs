using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoEcosystem.ImageService.Application.Albums.Commands;

namespace PhotoEcosystem.ImageService.API.Controllers;

[ApiController]
[Route("/api/[controller]s")]
public class AlbumController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ILogger<AlbumController> _logger;

    public AlbumController(ISender sender, ILogger<AlbumController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumCommand command)
    {
        _logger.LogInformation($"CreateAlbum: {command.Name}");
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return Ok();
    }
}
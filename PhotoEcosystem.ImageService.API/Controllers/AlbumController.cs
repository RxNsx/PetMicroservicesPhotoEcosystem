using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoEcosystem.ImageService.Application.Albums.Commands;
using PhotoEcosystem.ImageService.Application.Albums.GetById;
using PhotoEcosystem.ImageService.Application.Albums.Remove;
using PhotoEcosystem.ImageService.Application.Albums.Update;

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

    [HttpGet]
    [Route("[action]:{id:guid}")]
    public async Task<IActionResult> GetAlbums(Guid id)
    {
        _logger.LogInformation($"GetAlbum by Id: {id}");
        var query = new GetAlbumByIdQuery(id);
        var result = await _sender.Send(query);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }
        return Ok(result.Value);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> UpdateAlbum([FromBody] UpdateAlbumCommand command)
    {
        _logger.LogInformation($"Update Album with id: {command.AlbumId}");
        var result = await _sender.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return Ok(result.Value);
    }

    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> RemoveAlbum([FromBody] RemoveAlbumCommand command)
    {
        _logger.LogInformation($"Deleting Album with Id: {command.AlbumId}");
        var result = await _sender.Send(command);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return NoContent();
    }
}
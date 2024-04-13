using MediatR;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.Update;

public record UpdateAlbumCommand(Guid AlbumId, string Name) : IRequest<Result<AlbumAggregate>>
{
    
}
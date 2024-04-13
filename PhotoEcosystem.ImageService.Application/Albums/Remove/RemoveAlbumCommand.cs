using MediatR;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.Remove;

public record RemoveAlbumCommand(Guid AlbumId) : IRequest<Result>
{
    
}
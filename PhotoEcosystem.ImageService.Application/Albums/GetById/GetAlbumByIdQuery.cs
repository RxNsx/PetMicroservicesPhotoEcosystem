using MediatR;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.GetById;

public record GetAlbumByIdQuery(Guid Id) : IRequest<Result<AlbumAggregate>>
{
    
}
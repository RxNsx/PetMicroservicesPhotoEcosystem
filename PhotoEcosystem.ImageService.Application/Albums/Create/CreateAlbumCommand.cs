using MediatR;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.Commands;

public sealed record CreateAlbumCommand(string Name) : IRequest<Result>
{
}
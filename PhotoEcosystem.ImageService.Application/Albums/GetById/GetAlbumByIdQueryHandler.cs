using MediatR;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;
using PhotoEcosystem.ImageService.Domain.Interfaces;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.GetById;

public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, Result<AlbumAggregate>>
{
    private readonly IAlbumRepository _repository;

    public GetAlbumByIdQueryHandler(IAlbumRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result<AlbumAggregate>> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
    {
        var album = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (album is null)
        {
            return Result.Failure<AlbumAggregate>(Error.NullValue);
        }

        return Result.Success(album);
    }
}
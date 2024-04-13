using MediatR;
using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;
using PhotoEcosystem.ImageService.Domain.Interfaces;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.Remove;

public class RemoveAlbumCommandHandler : IRequestHandler<RemoveAlbumCommand, Result>
{
    private readonly IAlbumRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RemoveAlbumCommandHandler(IAlbumRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(RemoveAlbumCommand command, CancellationToken cancellationToken)
    {
        var result = await _repository.RemoveAsync(command.AlbumId, cancellationToken);
        if (!result)
        {
            return Result.Failure<AlbumAggregate>(Error.NullValue);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
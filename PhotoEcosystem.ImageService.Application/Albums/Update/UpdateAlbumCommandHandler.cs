using MediatR;
using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;
using PhotoEcosystem.ImageService.Domain.Interfaces;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.Update;

public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, Result<AlbumAggregate>>
{
    private readonly IAlbumRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateAlbumCommandHandler(IAlbumRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<AlbumAggregate>> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
    {
        var updatedAlbum = await _repository.GetByIdAsync(request.AlbumId, cancellationToken);
        updatedAlbum.ModifyAlbumName(request.Name);
        await _unitOfWork.SaveChangesAsync();

        var checkAlbum = await _repository.GetByIdAsync(request.AlbumId, cancellationToken);
        if (checkAlbum.AlbumName.Name != request.Name)
        {
            return Result.Failure<AlbumAggregate>(Error.LengthExceeded);
        }
        
        return Result.Success(updatedAlbum);
    }
}
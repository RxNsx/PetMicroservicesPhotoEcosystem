using MediatR;
using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Aggregates.Album;
using PhotoEcosystem.ImageService.Domain.Interfaces;
using Shared;

namespace PhotoEcosystem.ImageService.Application.Albums.Commands;

internal sealed class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Result>
{
    private readonly IAlbumRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAlbumCommandHandler(IAlbumRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateAlbumCommand command, CancellationToken cancellationToken)
    {
        var albumResult = AlbumName.Create(command.Name);
        if (albumResult.IsFailure)
        {
            return Result.Failure<Guid>(albumResult.Error);
        }
        
        await _repository.AddAlbumAsync(command.Name);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(albumResult.Value);
    }
}
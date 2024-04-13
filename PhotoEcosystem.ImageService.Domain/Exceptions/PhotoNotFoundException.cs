using PhotoEcosystem.ImageService.Domain.Exceptions.Base;

namespace PhotoEcosystem.ImageService.Domain.Exceptions;

public sealed class PhotoNotFoundException : NotFoundException
{
    public PhotoNotFoundException(Guid imageId)
        :base($"Изображение не найдено с Id: {imageId}")
    {
    }
}
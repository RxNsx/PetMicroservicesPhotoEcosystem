namespace PhotoEcosystem.ImageService.Domain.Exceptions.Base;

public class NotFoundException : Exception
{
    protected NotFoundException(string exceptionMessage)
        :base(exceptionMessage)
    {
    }
}
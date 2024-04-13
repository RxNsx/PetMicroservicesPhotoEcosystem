using Shared;
using Shared.Primitives;

namespace PhotoEcosystem.ImageService.Domain.Aggregates.Albums;

public class AlbumName : ValueObject
{
    public const int MaxLength = 50;
    public string Name { get; }

    private AlbumName() {}
    
    private AlbumName(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Создание имени альбома
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Result<AlbumName> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result.Failure<AlbumName>(Error.NullValue);
        }
        if (name.Length > MaxLength)
        {
            return Result.Failure<AlbumName>(Error.LengthExceeded);
        }
        return Result.Success(new AlbumName(name));
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }
}
namespace Shared.Primitives;

/// <summary>
/// Сущность
/// </summary>
public abstract class Entity<TGuid> : IEquatable<TGuid>
{
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, CreatedDate, ModifiedDate);
    }

    protected Entity(TGuid id)
    {
        if (!IsValid(Id))
        {
            throw new ArgumentException("Id is not valid", nameof(id));
        }
        
        Id = id;
        CreatedDate = DateTime.UtcNow;
        ModifiedDate = null;
    }

    protected Entity()
    {
    }
    
    public TGuid Id { get; protected set; }
    public DateTime CreatedDate { get; protected set; }
    public DateTime? ModifiedDate { get; protected set; }

    public bool Equals(TGuid? other)
    {
        return Id.Equals(other);
    }

    public bool Equals(Entity<TGuid> other)
    {
        return Id.GetHashCode().Equals(other.Id.GetHashCode());
    }
    
    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TGuid>);
    }

    public static bool operator ==(Entity<TGuid> left, Entity<TGuid> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Entity<TGuid> left, Entity<TGuid> right)
    {
        return left.Equals(right);
    }

    public bool IsValid(TGuid id)
    {
        return id is Guid;
    }
}
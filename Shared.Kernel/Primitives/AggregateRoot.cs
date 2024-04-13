namespace Shared.Primitives;

public abstract class AggregateRoot<TGuid> : Entity<TGuid>
{
    private readonly TGuid Id;

    protected AggregateRoot(TGuid id) : base(id)
    {
        Id = id;
    }

    protected AggregateRoot()
    {
    }
}
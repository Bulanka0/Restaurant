namespace Restaurant.Domain.Entities.Base;

public abstract class Entity<TId>(TId id) where TId : struct, IEquatable<TId>
{
    public TId Id { get; } = id;

    protected Entity() : this(default!)
    {
    }
}

namespace Blau.Entities;

public abstract class Entity<T>(T id) : IEntity
{
    private Entity() : this(default!) { }

    public T Id { get; protected set; } = id;
}

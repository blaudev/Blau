namespace Blau.Entities;

public abstract class Entity(Guid id)
{
    protected Entity() : this(Guid.NewGuid()) { }

    public Guid Id { get; protected set; } = id;
}

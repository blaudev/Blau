namespace Blau.Entities;

public abstract class Entity<T>
{
    protected Entity() { }

    public T Id { get; private set; } = default!;
}

namespace Blau.Entities;

public abstract class NamedEntity : Entity, INamedEntity
{
    public string Name { get; init; } = string.Empty;
}

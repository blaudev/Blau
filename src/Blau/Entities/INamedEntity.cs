namespace Blau.Entities;

public interface INamedEntity : IEntity
{
    string Name { get; init; }
}

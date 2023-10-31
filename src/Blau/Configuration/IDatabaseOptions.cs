namespace Blau.Configuration;

public interface IDatabaseOptions : IOptions
{
    string ConnectionString { get; }
}

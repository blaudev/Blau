namespace Blau.Exceptions;

public static class ObjectExtensions
{
    public static bool HasValue<T>(this T obj) => obj != null;

    public static T Value<T>(this T? obj) => obj ?? throw new NullReferenceException();
}

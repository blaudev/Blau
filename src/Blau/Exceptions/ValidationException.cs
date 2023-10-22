namespace Blau.Exceptions;

public class ValidationException(string name) : ExceptionBase($"{name} is not valid")
{
}

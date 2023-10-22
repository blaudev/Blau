using Blau.Exceptions;
using Blau.Extensions;

using System.Linq.Expressions;

namespace Blau.Validations;

public static class Validator
{
    public static void NotEmpty(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException(name);
    }

    public static void NotEmpty(Expression<Func<string?>> expr)
    {
        NotEmpty(expr.GeyFuncValue(), expr.GetFuncName());
    }

}

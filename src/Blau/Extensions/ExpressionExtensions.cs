using System.Linq.Expressions;

namespace Blau.Extensions;

public static class ExpressionExtensions
{
    public static string GetFuncName<T>(this Expression<Func<T>> expr)
    {
        var name = expr.Body switch
        {
            MemberExpression memberExpression => memberExpression.Member.Name,
            UnaryExpression unaryExpression => ((MemberExpression)unaryExpression.Operand).Member.Name,
            _ => throw new ArgumentException("Expression is not a member access", nameof(expr))
        };

        return name;
    }

    public static T GeyFuncValue<T>(this Expression<Func<T>> expr)
    {
        return expr.Compile().Invoke();
    }
}

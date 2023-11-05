using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.ComponentModel.DataAnnotations;

namespace Blau.Extensions;

public static class ModelBindingContextExtensions
{
    public static string GetFirstValue(this ModelBindingContext context, string key)
    {
        return context.ValueProvider.GetValue(key).FirstValue ?? throw new ValidationException(key);
    }
}

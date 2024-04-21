
namespace CleanArquitecture.Domain.Abstractions;

public record Error(string Code, string Name)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error nullValue = new("Error.NullValue", "Un valor Null fue ingresado");
}

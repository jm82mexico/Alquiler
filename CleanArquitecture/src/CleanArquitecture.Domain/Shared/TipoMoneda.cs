namespace CleanArquitecture.Domain.Shared;

public record TipoMoneda
{
    //Se encarga de manejar el tipo de moneda.
    //
    public static readonly TipoMoneda None = new("");
    public static readonly TipoMoneda Usd = new("USD");
    public static readonly TipoMoneda Eur = new("EUR");

    private TipoMoneda(string codigo) => Codigo = codigo;
    public string? Codigo { get; init; }

    //crea una lista de los tipos de moneda
    public static readonly IReadOnlyCollection<TipoMoneda> All = new[]   {
        
        Usd,
        Eur
    };

    //compara el código de la moneda con el código de la moneda que se le pasa
    public static TipoMoneda FromCodigo(string codigo)
    {
        return All.FirstOrDefault(c => c.Codigo == codigo) ??
            throw new ApplicationException($"No se encontró el tipo de moneda con el código {codigo}");
    }
}
namespace CleanArquitecture.Domain.Vehiculos;

public record Moneda(decimal Monto, TipoMoneda TipoMoneda)
{
    public static Moneda operator +(Moneda m1, Moneda m2)
    {
        if (m1.TipoMoneda != m2.TipoMoneda)
        {
            throw new ApplicationException("No se pueden sumar montos de diferentes monedas");
        }
        return new Moneda(m1.Monto + m2.Monto, m1.TipoMoneda);
    }

    public static Moneda Zero() => new (0, TipoMoneda.None);

    public static Moneda Zero(TipoMoneda tipoMoneda) => new (0, tipoMoneda);

    public bool IsZero() => this == Zero(TipoMoneda);
}

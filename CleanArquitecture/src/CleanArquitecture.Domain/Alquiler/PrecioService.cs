using CleanArquitecture.Domain.Vehiculos;

namespace CleanArquitecture.Domain.Alquiler;

public class PrecioService
{
    public PrecioDetalle CalcularPrecio(Vehiculo vehiculo,DateRange periodo)
    {
        var tipoMoneda = vehiculo.Precio!.TipoMoneda;

        var precioPorPeriodo = new Moneda(
            periodo.CantidadDias * vehiculo.Precio.Monto,
            tipoMoneda);
        
        decimal porcentageChange = 0;

        foreach (var accesorio in vehiculo.Accesorios)
        {
            porcentageChange += accesorio switch
            {
                Accesorio.Wifi or Accesorio.Radio => 0.05m,
                Accesorio.AireAcondicionado => 0.01m,
                Accesorio.AsientosCalefaccionados => 0.01m,
                _ => 0
            };
        }

        var accesorioChanges = Moneda.Zero(tipoMoneda);

        if (porcentageChange > 0)
        {
            accesorioChanges = new Moneda(
                precioPorPeriodo.Monto * porcentageChange,
                tipoMoneda);
        }

        var precioTotal  = Moneda.Zero(tipoMoneda);
        precioTotal += precioPorPeriodo;

        if(!vehiculo.Mantenimiento!.IsZero())
        {
            precioTotal += vehiculo.Mantenimiento;
        }

        precioTotal += accesorioChanges;

        return new PrecioDetalle(
            precioPorPeriodo,
            vehiculo.Mantenimiento,
            accesorioChanges,
            precioTotal);
    }
}

using CleanArquitecture.Domain.Vehiculos;

namespace CleanArquitecture.Domain.Alquiler;

public record PrecioDetalle
(

    Moneda PrecioPorPeriodo,
    Moneda Mantenimiento,
    Moneda Accesorios,
    Moneda PrecioTotal
);
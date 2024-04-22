using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Vehiculos;

public static class VehiculoErrors
{
    public static Error NotFound = new(
        "Vehiculo.NotFound",
        "No existe un vehiculo con el id especificado"
    );
}

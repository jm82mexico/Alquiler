using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Alquiler;

public static class AlquilerErrors
{
    public static Error NotFound = new Error(
        "Alquiler.NotFound",
        "El alquiler con el Id no fue encontrado"
    );

    public static Error Overlap = new Error(
        "Alquiler.Overlap",
        "El alquiler esta siendo tomado por 2 o más clientes al mismo tiempo en la misma fecha"
    );

    public static Error NotReserved = new Error(
        "Alquiler.NotReserved",
        "El alquiler no esta reservado"
    );

    public static Error NotConfirmed = new Error(
        "Alquiler.NotConfirmed",
        "El alquiler no esta confirmado"
    );

    public static Error AlReadyStarted = new Error(
        "Alquiler.AlReadyStarted",
        "El alquiler ya ha comenzado"
    );
}

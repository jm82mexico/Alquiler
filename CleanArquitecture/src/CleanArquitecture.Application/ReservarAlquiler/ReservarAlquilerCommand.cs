using CleanArquitecture.Application.Abstractions.Messaging;

namespace CleanArquitecture.Application.ReservarAlquiler;

public record ReservarAlquilerCommand
(
    Guid VehiculoId,
    Guid UserId,
    DateOnly FechaInicio,
    DateOnly FechaFin
):ICommand<Guid>;

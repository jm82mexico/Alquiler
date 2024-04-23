using CleanArquitecture.Application.Abstractions.Messaging;

namespace CleanArquitecture.Application.Alquiler.ReservarAlquiler;

public record ReservarAlquilerCommand
(
    Guid VehiculoId,
    Guid UserId,
    DateOnly FechaInicio,
    DateOnly FechaFin
):ICommand<Guid>;

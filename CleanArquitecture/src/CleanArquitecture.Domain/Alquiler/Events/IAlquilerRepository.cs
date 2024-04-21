using CleanArquitecture.Domain.Vehiculos;

namespace CleanArquitecture.Domain.Alquiler.Events;

public interface IAlquilerRepository
{
    Task<Alquiler?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlapAsync(
        Vehiculo vehiculo,
        DateRange duracion,
        CancellationToken cancellationToken = default
    );

    void Add(Alquiler alquiler);
}

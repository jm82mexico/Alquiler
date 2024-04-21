
using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Alquiler.Events;

public sealed record AlquilerConfirmadoDomainEvent(Guid AlquilerId) : IDomainEvent;


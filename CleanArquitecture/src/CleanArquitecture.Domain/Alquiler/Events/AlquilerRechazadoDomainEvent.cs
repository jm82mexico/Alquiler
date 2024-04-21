using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Alquiler.Events;

public sealed record AlquilerRechazadoDomainEvent(Guid AlquilerId) : IDomainEvent;

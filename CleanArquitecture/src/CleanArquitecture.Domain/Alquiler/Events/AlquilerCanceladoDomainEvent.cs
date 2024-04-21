using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Alquiler.Events;

public sealed record AlquilerCanceladoDomainEvent(Guid AlquilerId) : IDomainEvent;

using CleanArquitecture.Domain.Abstractions;
namespace CleanArquitecture.Domain.Alquiler.Events;

public sealed record AlquilerFinalizadoDomainEvent (Guid AlquilerId) : IDomainEvent;    

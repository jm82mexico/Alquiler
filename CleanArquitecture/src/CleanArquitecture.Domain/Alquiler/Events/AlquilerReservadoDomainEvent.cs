using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.Alquiler.Events
{
    public sealed record AlquilerReservadoDomainEvent(Guid AlquilerId) : IDomainEvent
    {
        
    }
}
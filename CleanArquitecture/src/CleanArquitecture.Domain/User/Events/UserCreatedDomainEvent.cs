using CleanArquitecture.Domain.Abstractions;

namespace CleanArquitecture.Domain.User.Events;

//Evento de dominio que se lanza cuando se crea un usuario
public sealed record UserCreatedDomainEvent(Guid UserId): IDomainEvent;

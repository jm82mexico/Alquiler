using CleanArquitecture.Domain.Abstractions;
namespace CleanArquitecture.Domain.Review.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;


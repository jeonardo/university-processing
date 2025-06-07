namespace UniversityProcessing.Core.DomainEvents.UserEvents;

public sealed record UserCreatedEvent(Guid UserId, Email Email) : IDomainEvent;

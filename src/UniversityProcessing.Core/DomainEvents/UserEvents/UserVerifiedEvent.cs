namespace UniversityProcessing.Core.DomainEvents.UserEvents;

public record UserVerifiedEvent(Guid UserId) : IDomainEvent;

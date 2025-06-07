namespace UniversityProcessing.Core.DomainEvents;

public sealed record DiplomaProjectSubmittedEvent(Guid ProjectId) : IDomainEvent;

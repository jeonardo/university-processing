using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Events;

public sealed class DiplomaProcessGroupAddedEvent : DomainEventBase
{
    public required long DiplomaProcessId { get; set; }
    public required long GroupId { get; set; }
}

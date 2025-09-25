using Ardalis.SharedKernel;

namespace UniversityProcessing.Domain.Events;

public sealed class DiplomaProcessGroupAddedEvent : DomainEventBase
{
    public required Guid DiplomaProcessId { get; set; }
    public required Guid GroupId { get; set; }
}

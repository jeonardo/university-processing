using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GroupDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
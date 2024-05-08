using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class GroupDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
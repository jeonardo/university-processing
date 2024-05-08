using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class GroupGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
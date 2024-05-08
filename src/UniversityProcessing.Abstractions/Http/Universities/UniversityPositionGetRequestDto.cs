using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityPositionGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
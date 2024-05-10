using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityPositionGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
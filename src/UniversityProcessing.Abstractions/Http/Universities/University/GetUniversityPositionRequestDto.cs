using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversityPositionRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

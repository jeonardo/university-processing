using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversityRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

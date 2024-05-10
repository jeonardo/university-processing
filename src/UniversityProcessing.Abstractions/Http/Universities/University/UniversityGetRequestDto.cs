using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
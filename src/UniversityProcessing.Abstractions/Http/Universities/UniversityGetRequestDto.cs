using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
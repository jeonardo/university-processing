using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class SpecialtyGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
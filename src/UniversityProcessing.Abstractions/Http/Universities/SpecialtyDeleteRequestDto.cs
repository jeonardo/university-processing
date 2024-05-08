using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class SpecialtyDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
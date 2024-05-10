using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class SpecialtyDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
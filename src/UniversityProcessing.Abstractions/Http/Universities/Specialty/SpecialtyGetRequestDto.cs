using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class SpecialtyGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
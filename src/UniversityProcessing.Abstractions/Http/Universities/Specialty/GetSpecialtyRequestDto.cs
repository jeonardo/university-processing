using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class GetSpecialtyRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

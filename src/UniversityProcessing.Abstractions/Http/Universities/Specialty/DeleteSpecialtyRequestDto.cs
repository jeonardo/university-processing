using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class DeleteSpecialtyRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

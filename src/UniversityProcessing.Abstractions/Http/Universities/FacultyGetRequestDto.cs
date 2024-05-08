using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class FacultyGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
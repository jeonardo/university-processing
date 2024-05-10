using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class FacultyDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
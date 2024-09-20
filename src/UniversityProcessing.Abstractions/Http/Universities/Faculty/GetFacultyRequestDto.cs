using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class GetFacultyRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

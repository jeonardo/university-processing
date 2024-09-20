using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class DeleteFacultyRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

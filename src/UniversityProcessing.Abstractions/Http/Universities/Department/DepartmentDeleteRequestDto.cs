using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class DepartmentDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
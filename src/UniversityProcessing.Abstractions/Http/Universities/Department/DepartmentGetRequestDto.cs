using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Department;

public sealed class DepartmentGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class DepartmentGetRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}
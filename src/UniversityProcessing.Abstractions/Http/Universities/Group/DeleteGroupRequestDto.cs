using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class DeleteGroupRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

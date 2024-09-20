using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.Group;

public sealed class GetGroupRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class GetUserRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

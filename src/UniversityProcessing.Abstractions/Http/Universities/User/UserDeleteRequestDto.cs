using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class UserDeleteRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

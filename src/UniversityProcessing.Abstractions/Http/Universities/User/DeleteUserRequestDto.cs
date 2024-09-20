using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class DeleteUserRequestDto
{
    [NotDefault]
    public Guid Id { get; set; }
}

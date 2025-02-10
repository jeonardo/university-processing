namespace UniversityProcessing.API.Endpoints.Identity.Info;

public sealed class UserDto(Guid id)
{
    public Guid Id { get; set; } = id;
}

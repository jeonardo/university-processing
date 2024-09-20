namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class GetUserResponseDto(UserDto department)
{
    public UserDto User { get; set; } = department;
}

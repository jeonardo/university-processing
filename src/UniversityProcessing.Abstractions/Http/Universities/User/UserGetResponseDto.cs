namespace UniversityProcessing.Abstractions.Http.Universities.User;

public sealed class UserGetResponseDto(UserDto department)
{
    public UserDto User { get; set; } = department;
}

namespace UniversityProcessing.API.Endpoints.Auth.Login;

public sealed class LoginResponseDto(string? accessToken, string? refreshToken)
{
    public string? AccessToken { get; set; } = accessToken;
    public string? RefreshToken { get; set; } = refreshToken;
}

namespace UniversityProcessing.API.Endpoints.Auth.Login;

public sealed class ResponseDto(string? accessToken, string? refreshToken)
{
    public string? AccessToken { get; set; } = accessToken;
    public string? RefreshToken { get; set; } = refreshToken;
}

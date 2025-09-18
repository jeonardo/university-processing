namespace UniversityProcessing.API.Endpoints.Auth.Refresh;

public sealed class ResponseDto(string? accessToken, string? refreshToken)
{
    public string? AccessToken { get; set; } = accessToken;
    public string? RefreshToken { get; set; } = refreshToken;
}

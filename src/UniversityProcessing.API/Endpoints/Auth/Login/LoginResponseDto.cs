using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Auth.Login;

public sealed class LoginResponseDto(TokenDto accessToken, TokenDto refreshToken)
{
    public TokenDto AccessToken { get; set; } = accessToken;
    public TokenDto RefreshToken { get; set; } = refreshToken;
}

using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.Abstractions.Http.Authenticate;

public sealed class RefreshResponseDto(TokenDto accessToken, TokenDto refreshToken) : SuccessResponse
{
    public TokenDto AccessToken { get; init; } = accessToken;
    public TokenDto RefreshToken { get; init; } = refreshToken;
}
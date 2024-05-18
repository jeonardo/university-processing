using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.Abstractions.Http.Identity;

public sealed class RefreshResponseDto(TokenDto accessToken, TokenDto refreshToken)
{
    public TokenDto AccessToken { get; init; } = accessToken;
    public TokenDto RefreshToken { get; init; } = refreshToken;
}
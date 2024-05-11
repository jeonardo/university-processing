﻿using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.Abstractions.Http.Identity;

public sealed class LoginResponseDto(TokenDto accessToken, TokenDto refreshToken) : SuccessResponse
{
    public TokenDto AccessToken { get; init; } = accessToken;
    public TokenDto RefreshToken { get; init; } = refreshToken;
}
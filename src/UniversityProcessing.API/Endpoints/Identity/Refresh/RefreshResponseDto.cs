﻿using UniversityProcessing.API.Endpoints.Contracts;

namespace UniversityProcessing.API.Endpoints.Identity.Refresh;

public sealed class RefreshResponseDto(TokenDto accessToken, TokenDto refreshToken)
{
    public TokenDto AccessToken { get; set; } = accessToken;
    public TokenDto RefreshToken { get; set; } = refreshToken;
}
using UniversityProcessing.Abstractions.Http.Authenticate;
using UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class LoginResponseConverter
{
    public static LoginResponseDto ToDto(LoginCommandResponse input)
    {
        return new LoginResponseDto(
            TokenConverter.ToDto(input.AccessToken),
            TokenConverter.ToDto(input.RefreshToken));
    }
}
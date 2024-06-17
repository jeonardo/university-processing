using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;

namespace UniversityProcessing.API.Controllers.Identity;

internal static class LoginResponseConverter
{
    public static LoginResponseDto ToDto(LoginCommandResponse input)
    {
        return new LoginResponseDto(
            TokenConverter.ToDto(input.AccessToken),
            TokenConverter.ToDto(input.RefreshToken));
    }
}

using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.DomainServices.Features.Identity.Login.Contracts;

namespace UniversityProcessing.API.Controllers.Identity;

internal static class LoginRequestConverter
{
    public static LoginCommandRequest ToInternal(LoginRequestDto input)
    {
        return new LoginCommandRequest(input.UserName, input.Password);
    }
}

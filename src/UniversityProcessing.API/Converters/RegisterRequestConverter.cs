using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.DomainServices.Features.Identity.Register.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class RegisterRequestConverter
{
    public static RegisterCommandRequest ToInternal(RegisterRequestDto input)
    {
        return new RegisterCommandRequest(input.UserName, input.Password);
    }
}
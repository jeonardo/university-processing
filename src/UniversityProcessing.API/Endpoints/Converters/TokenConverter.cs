using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.GenericSubdomain.Authorization;

namespace UniversityProcessing.API.Endpoints.Converters;

internal static class TokenConverter
{
    public static TokenDto ToDto(Token input)
    {
        return new TokenDto(input.Value, input.Expiration);
    }
}

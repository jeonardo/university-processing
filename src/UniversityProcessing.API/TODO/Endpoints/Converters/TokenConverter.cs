using UniversityProcessing.API.TODO.Endpoints.Contracts;
using UniversityProcessing.GenericSubdomain.Authorization;

namespace UniversityProcessing.API.TODO.Endpoints.Converters;

internal static class TokenConverter
{
    public static TokenDto ToDto(Token input)
    {
        return new TokenDto(input.Value, input.Expiration);
    }
}

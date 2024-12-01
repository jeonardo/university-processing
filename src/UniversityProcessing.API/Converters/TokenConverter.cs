using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain;

namespace UniversityProcessing.API.Converters;

internal static class TokenConverter
{
    public static TokenDto ToDto(Token input)
    {
        return new TokenDto(input.Value, input.Expiration);
    }
}

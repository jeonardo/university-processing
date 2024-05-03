using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Converters;

internal static class TokenConverter
{
    public static TokenDto ToDto(Token input)
    {
        return new TokenDto(input.Value, input.Expiration);
    }

    public static Token ToInternal(TokenDto input)
    {
        return new Token(input.Value, input.Expiration);
    }
}
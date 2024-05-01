using UniversityProcessing.Abstractions.Http.Authenticate;
using UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

namespace UniversityProcessing.API.Converters;

internal static class RefreshResponseConverter
{
    public static RefreshResponseDto ToDto(RefreshCommandResponse input)
    {
        return new RefreshResponseDto(
            TokenConverter.ToDto(input.AccessToken),
            TokenConverter.ToDto(input.RefreshToken));
    }
}
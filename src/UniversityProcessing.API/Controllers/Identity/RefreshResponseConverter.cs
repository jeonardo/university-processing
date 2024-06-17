using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.DomainServices.Features.Identity.Refresh.Contracts;

namespace UniversityProcessing.API.Controllers.Identity;

internal static class RefreshResponseConverter
{
    public static RefreshResponseDto ToDto(RefreshCommandResponse input)
    {
        return new RefreshResponseDto(
            TokenConverter.ToDto(input.AccessToken),
            TokenConverter.ToDto(input.RefreshToken));
    }
}

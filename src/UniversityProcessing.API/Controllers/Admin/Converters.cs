using UniversityProcessing.Abstractions.Http.Admin;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Users.GetList;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Controllers.Admin;

internal static class Converters
{
    public static AdminGetUsersResponseDto ToAdminGetUsersResponseDto(this GetUsersQueryResponse response)
    {
        return new AdminGetUsersResponseDto(
            new PagedList<UserDto>(
                response.List.Items.Select(ToDto),
                response.List.TotalCount,
                response.List.CurrentPage,
                response.List.PageSize));
    }

    private static UserDto ToDto(User user)
    {
        return new UserDto(user.Id, user.FirstName, user.LastName, user.MiddleName, user.Approved);
    }
}

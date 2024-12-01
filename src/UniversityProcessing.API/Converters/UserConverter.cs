using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Converters;

public static class UserConverter
{
    public static PagedList<UserDto> ToDto(PagedList<User> input)
    {
        return new PagedList<UserDto>(ToDto(input.Items), input.TotalCount, input.CurrentPage, input.PageSize);
    }

    public static IEnumerable<UserDto> ToDto(IEnumerable<User> input)
    {
        return input.Select((x, _) => ToDto(x));
    }

    public static UserDto ToDto(User input)
    {
        return new UserDto(
            input.Id,
            input.FirstName,
            input.LastName,
            input.MiddleName,
            input.Email,
            input.Birthday);
    }
}

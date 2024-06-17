using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Converters;

public sealed class UserConverter
{
    public static PagedList<UserDto> ToPagedDto(IEnumerable<User> input, int totalCount, int pageNumber, int pageSize)
    {
        return new PagedList<UserDto>(ToDto(input), totalCount, pageNumber, pageSize);
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

using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Converters;

public static class UserRoleIdConverter
{
    public static UserRoleIdDto[] ToDto(this UserRoles[] input)
    {
        return input.Select(ToDto).ToArray();
    }

    public static UserRoleIdDto ToDto(this UserRoles input)
    {
        return input switch
        {
            UserRoles.ApplicationAdmin => UserRoleIdDto.ApplicationAdmin,
            UserRoles.Employee => UserRoleIdDto.Employee,
            UserRoles.Student => UserRoleIdDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }

    public static UserRoles ToInternal(this UserRoleIdDto input)
    {
        return input switch
        {
            UserRoleIdDto.Employee => UserRoles.Employee,
            UserRoleIdDto.Student => UserRoles.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}

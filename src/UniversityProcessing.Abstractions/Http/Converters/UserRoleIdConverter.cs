using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.Abstractions.Http.Converters;

public static class UserRoleIdConverter
{
    public static UserRoleIdDto[] ToDto(this UserRoleId[] input)
    {
        return input.Select(ToDto).ToArray();
    }

    public static UserRoleIdDto ToDto(this UserRoleId input)
    {
        return input switch
        {
            UserRoleId.ApplicationAdmin => UserRoleIdDto.ApplicationAdmin,
            UserRoleId.Employee => UserRoleIdDto.Employee,
            UserRoleId.Student => UserRoleIdDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }

    public static UserRoleId ToInternal(this UserRoleIdDto input)
    {
        return input switch
        {
            UserRoleIdDto.Employee => UserRoleId.Employee,
            UserRoleIdDto.Student => UserRoleId.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}

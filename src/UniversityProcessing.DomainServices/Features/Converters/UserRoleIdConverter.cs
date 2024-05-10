using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Domain.Identity.Enums;

namespace UniversityProcessing.DomainServices.Features.Converters;

public static class UserRoleIdConverter
{
    public static UserRoleIdDto ToDto(UserRoleId input)
    {
        return input switch
        {
            UserRoleId.ApplicationAdmin => UserRoleIdDto.ApplicationAdmin,
            UserRoleId.Employee => UserRoleIdDto.Employee,
            UserRoleId.Student => UserRoleIdDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }

    public static UserRoleId ToInternal(UserRoleIdDto input)
    {
        return input switch
        {
            UserRoleIdDto.Employee => UserRoleId.Employee,
            UserRoleIdDto.Student => UserRoleId.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}
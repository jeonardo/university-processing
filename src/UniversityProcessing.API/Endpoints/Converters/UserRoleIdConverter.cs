using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Endpoints.Converters;

internal static class UserRoleIdConverter
{
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
}

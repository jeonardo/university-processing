using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Endpoints.Converters;

internal static class UserRoleIdConverter
{
    public static UserRoleDto ToDto(this UserRoleType input)
    {
        return input switch
        {
            UserRoleType.ApplicationAdmin => UserRoleDto.ApplicationAdmin,
            UserRoleType.Employee => UserRoleDto.Employee,
            UserRoleType.Student => UserRoleDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}

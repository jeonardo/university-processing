using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Endpoints.Converters;

internal static class UserRoleIdConverter
{
    public static UserRoleIdDto ToDto(this UserRoleType input)
    {
        return input switch
        {
            UserRoleType.ApplicationAdmin => UserRoleIdDto.ApplicationAdmin,
            UserRoleType.Employee => UserRoleIdDto.Employee,
            UserRoleType.Student => UserRoleIdDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}

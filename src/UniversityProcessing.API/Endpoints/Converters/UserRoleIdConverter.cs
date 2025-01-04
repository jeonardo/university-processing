using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain.Identity;

namespace UniversityProcessing.API.Endpoints.Converters;

internal static class UserRoleIdConverter
{
    public static UserRoleTypeDto ToDto(this UserRoleType input)
    {
        return input switch
        {
            UserRoleType.Admin => UserRoleTypeDto.Admin,
            UserRoleType.Employee => UserRoleTypeDto.Employee,
            UserRoleType.Student => UserRoleTypeDto.Student,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}

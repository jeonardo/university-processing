using UniversityProcessing.API.TODO.Endpoints.Contracts;
using UniversityProcessing.Domain;

namespace UniversityProcessing.API.TODO.Endpoints.Converters;

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

using UniversityProcessing.API.Endpoints.Contracts;
using UniversityProcessing.Domain;
using UniversityProcessing.Domain.Users;

namespace UniversityProcessing.API.Endpoints.Converters;

internal static class UserRoleIdConverter
{
    public static UserRoleTypeDto ToDto(this UserRoleType input)
    {
        return input switch
        {
            UserRoleType.Admin => UserRoleTypeDto.Admin,
            UserRoleType.Student => UserRoleTypeDto.Student,
            UserRoleType.Teacher => UserRoleTypeDto.Teacher,
            UserRoleType.Deanery => UserRoleTypeDto.Deanery,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}

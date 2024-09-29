using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;
using UniversityProcessing.Abstractions.Http.Identity.RegisterStudent;
using UniversityProcessing.DomainServices.Features.Identity.RegisterAdmin;
using UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.Register;
using UniversityProcessing.DomainServices.Features.Identity.RegisterStudent.GetRegisterStudentAvailableGroups;
using UniversityProcessing.DomainServices.Features.Identity.RegisterStudent.Register;

namespace UniversityProcessing.API.Controllers.Identity;

internal static class Converters
{
    public static RegisterEmployeeCommandRequest ToRegisterEmployeeCommandRequest(this RegisterEmployeeRequestDto input)
    {
        return new RegisterEmployeeCommandRequest(
            input.UserName,
            input.Password,
            input.FirstName,
            input.LastName,
            input.MiddleName,
            input.Email,
            input.Birthday.HasValue
                ? DateOnly.FromDateTime(input.Birthday.Value)
                : null,
            input.UniversityId,
            input.UniversityPositionId);
    }

    public static GetRegisterStudentAvailableGroupsQueryRequest ToGetRegisterStudentAvailableGroupsQueryRequest(this GetRegisterStudentAvailableGroupsRequestDto input)
    {
        return new GetRegisterStudentAvailableGroupsQueryRequest(input.Number);
    }

    public static RegisterStudentCommandRequest ToRegisterStudentCommandRequest(this RegisterStudentRequestDto input)
    {
        return new RegisterStudentCommandRequest(
            input.UserName,
            input.Password,
            input.FirstName,
            input.LastName,
            input.MiddleName,
            input.Email,
            input.Birthday.HasValue
                ? DateOnly.FromDateTime(input.Birthday.Value)
                : null,
            input.GroupNumber);
    }

    public static GetRegisterStudentAvailableGroupsResponseDto ToGetRegisterStudentAvailableGroupsResponseDto(
        this GetRegisterStudentAvailableGroupsQueryResponse response)
    {
        return new GetRegisterStudentAvailableGroupsResponseDto(response.List);
    }

    public static RegisterAdminCommandRequest ToRegisterAdminCommandRequest(this RegisterAdminRequestDto input)
    {
        return new RegisterAdminCommandRequest(
            input.UserName,
            input.Password,
            input.FirstName,
            input.LastName,
            input.MiddleName,
            input.Email,
            input.Birthday.HasValue
                ? DateOnly.FromDateTime(input.Birthday.Value)
                : null);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Identity;
using UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;
using UniversityProcessing.Abstractions.Http.Identity.RegisterStudent;
using UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.GetRegisterEmployeeAvailableUniversities;
using UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee.GetRegisterEmployeeAvailableUniversityPositions;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers.Identity;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class RegistrationController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [ValidateModel]
    public Task RegisterAdmin([FromBody] RegisterAdminRequestDto request, CancellationToken cancellationToken)
    {
        var command = request.ToRegisterAdminCommandRequest();
        return mediator.Send(command, cancellationToken);
    }

    [HttpPost]
    [ValidateModel]
    public Task RegisterStudent([FromBody] RegisterStudentRequestDto request, CancellationToken cancellationToken)
    {
        var command = request.ToRegisterStudentCommandRequest();
        return mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [ValidateModel]
    public async Task<GetRegisterStudentAvailableGroupsResponseDto> GetAvailableGroups(
        [FromQuery] GetRegisterStudentAvailableGroupsRequestDto request,
        CancellationToken cancellationToken)
    {
        var query = request.ToGetRegisterStudentAvailableGroupsQueryRequest();
        var response = await mediator.Send(query, cancellationToken);
        return response.ToGetRegisterStudentAvailableGroupsResponseDto();
    }

    [HttpPost]
    [ValidateModel]
    public Task RegisterEmployee([FromBody] RegisterEmployeeRequestDto request, CancellationToken cancellationToken)
    {
        var command = request.ToRegisterEmployeeCommandRequest();
        return mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [ValidateModel]
    public async Task<GetRegisterEmployeeAvailableUniversitiesResponseDto> GetAvailableUniversities(
        [FromQuery] GetRegisterEmployeeAvailableUniversitiesRequestDto request,
        CancellationToken cancellationToken)
    {
        var query = new GetRegisterEmployeeAvailableUniversitiesQueryRequest(request.Name);
        var response = await mediator.Send(query, cancellationToken);
        return new GetRegisterEmployeeAvailableUniversitiesResponseDto(response.Universities);
    }

    [HttpGet]
    public async Task<GetRegisterEmployeeAvailableUniversityPositionsResponseDto> GetAvailableUniversityPositions(CancellationToken cancellationToken)
    {
        var query = new GetRegisterEmployeeAvailableUniversityPositionsQueryRequest();
        var response = await mediator.Send(query, cancellationToken);
        return new GetRegisterEmployeeAvailableUniversityPositionsResponseDto(response.UniversityPositions);
    }
}

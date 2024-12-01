using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.API.Converters;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Departments.Create;
using UniversityProcessing.DomainServices.Features.Departments.Delete;
using UniversityProcessing.DomainServices.Features.Departments.Get;
using UniversityProcessing.DomainServices.Features.Departments.GetList;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class DepartmentController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<GetDepartmentResponseDto> Get([FromQuery] GetDepartmentRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetDepartmentResponseDto(DepartmentConverter.ToDto(response.Department));
    }

    [HttpGet]
    public async Task<GetDepartmentsResponseDto> GetList([FromQuery] GetDepartmentsRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentsQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetDepartmentsResponseDto(DepartmentConverter.ToDto(response.List));
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    public async Task<CreateDepartmentResponseDto> Create([FromBody] CreateDepartmentRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateDepartmentCommandRequest(request.Name, request.ShortName, request.FacultyId);
        var response = await mediator.Send(command, cancellationToken);
        return new CreateDepartmentResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    public Task Delete([FromBody] DeleteDepartmentRequestDto request, CancellationToken cancellationToken)
    {
        var command = new DeleteDepartmentCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

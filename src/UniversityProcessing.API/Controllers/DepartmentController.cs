using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Departments.Create;
using UniversityProcessing.DomainServices.Features.Departments.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Departments.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class DepartmentController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<DepartmentGetResponseDto> Get([FromQuery] DepartmentGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new DepartmentGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new DepartmentGetResponseDto(response.Department);
    }

    [HttpGet]
    public async Task<DepartmentListResponseDto> GetList([FromQuery] DepartmentListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new DepartmentListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new DepartmentListResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<DepartmentCreateResponseDto> Create([FromBody] DepartmentCreateRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateDepartmentCommandRequest(request.Name, request.ShortName, request.FacultyId);
        var response = await mediator.Send(command, cancellationToken);
        return new DepartmentCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] DepartmentDeleteRequestDto request, CancellationToken cancellationToken)
    {
        var command = new DepartmentDeleteCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

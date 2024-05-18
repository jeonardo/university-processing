using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.DomainServices.Features.Departments.Create.Contracts;
using UniversityProcessing.DomainServices.Features.Departments.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Departments.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class DepartmentController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(DepartmentGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<DepartmentGetResponseDto> Get([FromRoute] DepartmentGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DepartmentGetQueryRequest(request.Id), cancellationToken);
        return new DepartmentGetResponseDto(response.Department);
    }

    [HttpGet]
    [ProducesResponseType(typeof(DepartmentListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<DepartmentListResponseDto> List([FromQuery] DepartmentListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new DepartmentListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new DepartmentListResponseDto(response.List);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DepartmentCreateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public async Task<DepartmentCreateResponseDto> Create([FromQuery] DepartmentCreateRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new DepartmentCreateCommandRequest(request.Name, request.ShortName, request.FacultyId), cancellationToken);
        return new DepartmentCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Delete([FromBody] DepartmentDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new DepartmentDeleteCommandRequest(request.Id), cancellationToken);
    }
}
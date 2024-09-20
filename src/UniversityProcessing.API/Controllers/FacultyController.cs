using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Faculty;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Faculties.Create;
using UniversityProcessing.DomainServices.Features.Faculties.Delete;
using UniversityProcessing.DomainServices.Features.Faculties.Get;
using UniversityProcessing.DomainServices.Features.Faculties.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class FacultyController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<GetFacultyResponseDto> Get([FromQuery] GetFacultyRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetFacultyQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetFacultyResponseDto(response.Faculty);
    }

    [HttpGet]
    public async Task<GetFacultiesResponseDto> GetList([FromQuery] GetFacultiesRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetFacultiesQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetFacultiesResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<CreateFacultyResponseDto> Create([FromBody] CreateFacultyRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateFacultyCommandRequest(request.Name, request.ShortName, request.UniversityId);
        var response = await mediator.Send(command, cancellationToken);
        return new CreateFacultyResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] DeleteFacultyRequestDto request, CancellationToken cancellationToken)
    {
        var command = new DeleteFacultyCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

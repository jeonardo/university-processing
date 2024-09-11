using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Faculty;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Faculties.Create;
using UniversityProcessing.DomainServices.Features.Faculties.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Faculties.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Faculties.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class FacultyController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<FacultyGetResponseDto> Get([FromQuery] FacultyGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new FacultyGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new FacultyGetResponseDto(response.Faculty);
    }

    [HttpGet]
    public async Task<FacultyListResponseDto> GetList([FromQuery] FacultyListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new FacultyListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new FacultyListResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<FacultyCreateResponseDto> Create([FromBody] FacultyCreateRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateFacultyCommandRequest(request.Name, request.ShortName, request.UniversityId);
        var response = await mediator.Send(command, cancellationToken);
        return new FacultyCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] FacultyDeleteRequestDto request, CancellationToken cancellationToken)
    {
        var command = new FacultyDeleteCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

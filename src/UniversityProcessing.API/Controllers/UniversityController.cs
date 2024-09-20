using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Universities.Create;
using UniversityProcessing.DomainServices.Features.Universities.Delete;
using UniversityProcessing.DomainServices.Features.Universities.Get;
using UniversityProcessing.DomainServices.Features.Universities.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UniversityController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<GetUniversityResponseDto> Get([FromQuery] GetUniversityRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUniversityQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetUniversityResponseDto(response.University);
    }

    [HttpGet]
    public async Task<GetUniversitiesResponseDto> GetList([FromQuery] GetUniversitiesRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUniversitiesQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetUniversitiesResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<CreateUniversityResponseDto> Create([FromBody] CreateUniversityRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateUniversityCommandRequest(request.Name, request.ShortName);
        var response = await mediator.Send(command, cancellationToken);
        return new CreateUniversityResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] DeleteUniversityRequestDto request, CancellationToken cancellationToken)
    {
        var command = new DeleteUniversityCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

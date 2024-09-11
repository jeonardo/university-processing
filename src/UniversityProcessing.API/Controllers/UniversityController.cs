using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Universities.Create;
using UniversityProcessing.DomainServices.Features.Universities.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Universities.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UniversityController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<UniversityGetResponseDto> Get([FromQuery] UniversityGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new UniversityGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new UniversityGetResponseDto(response.University);
    }

    [HttpGet]
    public async Task<UniversityListResponseDto> GetList([FromQuery] UniversityListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new UniversityListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new UniversityListResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<UniversityCreateResponseDto> Create([FromBody] UniversityCreateRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateUniversityCommandRequest(request.Name, request.ShortName);
        var response = await mediator.Send(command, cancellationToken);
        return new UniversityCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] UniversityDeleteRequestDto request, CancellationToken cancellationToken)
    {
        var command = new UniversityDeleteCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

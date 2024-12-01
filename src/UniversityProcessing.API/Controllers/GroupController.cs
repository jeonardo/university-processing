using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.API.Converters;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Groups.Create;
using UniversityProcessing.DomainServices.Features.Groups.Delete;
using UniversityProcessing.DomainServices.Features.Groups.Get;
using UniversityProcessing.DomainServices.Features.Groups.GetList;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<GetGroupResponseDto> Get([FromQuery] GetGroupRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetGroupQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return GroupConverter.ToDto(response);
    }

    [HttpGet]
    public async Task<GetGroupsResponseDto> GetList([FromQuery] GetGroupsRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetGroupsQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return GroupConverter.ToDto(response);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    public async Task<CreateGroupResponseDto> Create([FromBody] CreateGroupRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateGroupCommandRequest(request.GroupNumber, request.StartDate, request.EndDate, request.SpecialtyId);
        var response = await mediator.Send(command, cancellationToken);
        return new CreateGroupResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    public Task Delete([FromBody] DeleteGroupRequestDto request, CancellationToken cancellationToken)
    {
        var command = new DeleteGroupCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

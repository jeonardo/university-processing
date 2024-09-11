using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.DomainServices.Features.Groups.Create;
using UniversityProcessing.DomainServices.Features.Groups.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Groups.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<GroupGetResponseDto> Get([FromQuery] GroupGetRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GroupGetQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GroupGetResponseDto(response.Group);
    }

    [HttpGet]
    public async Task<GroupListResponseDto> GetList([FromQuery] GroupListRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GroupListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GroupListResponseDto(response.List);
    }

    [HttpPost]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public async Task<GroupCreateResponseDto> Create([FromBody] GroupCreateRequestDto request, CancellationToken cancellationToken)
    {
        var command = new CreateGroupCommandRequest(request.GroupNumber, request.StartDate, request.EndDate, request.SpecialtyId);
        var response = await mediator.Send(command, cancellationToken);
        return new GroupCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [Authorize(Roles = nameof(UserRoles.ApplicationAdmin))]
    [ValidateModel]
    public Task Delete([FromBody] GroupDeleteRequestDto request, CancellationToken cancellationToken)
    {
        var command = new GroupDeleteCommandRequest(request.Id);
        return mediator.Send(command, cancellationToken);
    }
}

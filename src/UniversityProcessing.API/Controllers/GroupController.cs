using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.DomainServices.Features.Groups.Create.Contracts;
using UniversityProcessing.DomainServices.Features.Groups.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Groups.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class GroupController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(GroupGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<GroupGetResponseDto> Get([FromRoute] GroupGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new GroupGetQueryRequest(request.Id), cancellationToken);
        return new GroupGetResponseDto(response.Group);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GroupListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<GroupListResponseDto> List([FromQuery] GroupListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new GroupListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new GroupListResponseDto(response.List);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GroupCreateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public async Task<GroupCreateResponseDto> Create([FromBody] GroupCreateRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new GroupCreateCommandRequest(request.GroupNumber, request.StartDate, request.EndDate, request.SpecialtyId),
            cancellationToken);
        return new GroupCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Delete([FromBody] GroupDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new GroupDeleteCommandRequest(request.Id), cancellationToken);
    }
}

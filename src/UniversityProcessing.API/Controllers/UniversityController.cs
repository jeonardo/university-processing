using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.DomainServices.Features.Universities.Create.Contracts;
using UniversityProcessing.DomainServices.Features.Universities.Delete.Contracts;
using UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;
using UniversityProcessing.DomainServices.Features.Universities.List.Contracts;
using UniversityProcessing.GenericSubdomain.Attributes;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UniversityController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(UniversityGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<UniversityGetResponseDto> Get([FromRoute] UniversityGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new UniversityGetQueryRequest(request.Id), cancellationToken);
        return new UniversityGetResponseDto(response.University);
    }

    [HttpGet]
    [ProducesResponseType(typeof(UniversityListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<UniversityListResponseDto> List([FromQuery] UniversityListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new UniversityListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new UniversityListResponseDto(response.List);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UniversityCreateResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public async Task<UniversityCreateResponseDto> Create([FromQuery] UniversityCreateRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new UniversityCreateCommandRequest(request.Name, request.ShortName), cancellationToken);
        return new UniversityCreateResponseDto(response.Id);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ValidateModel]
    public Task Delete([FromBody] UniversityDeleteRequestDto request, CancellationToken cancellationToken)
    {
        return mediator.Send(new UniversityDeleteCommandRequest(request.Id), cancellationToken);
    }
}
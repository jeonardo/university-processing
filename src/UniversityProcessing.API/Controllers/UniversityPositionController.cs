using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.DomainServices.Features.UniversityPositions.Get.Contracts;
using UniversityProcessing.DomainServices.Features.UniversityPositions.List.Contracts;
using UniversityProcessing.GenericSubdomain.Http;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UniversityPositionController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(UniversityPositionGetResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<UniversityPositionGetResponseDto> Get([FromRoute] UniversityPositionGetRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new UniversityPositionGetQueryRequest(request.Id), cancellationToken);
        return new UniversityPositionGetResponseDto(response.UniversityPosition);
    }

    [HttpGet]
    [ProducesResponseType(typeof(UniversityPositionListResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(FailResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<UniversityPositionListResponseDto> List([FromQuery] UniversityPositionListRequestDto request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(
            new UniversityPositionListQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc),
            cancellationToken);
        return new UniversityPositionListResponseDto(response.List);
    }
}
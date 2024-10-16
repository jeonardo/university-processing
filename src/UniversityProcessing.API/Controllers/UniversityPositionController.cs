using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.API.Converters;
using UniversityProcessing.DomainServices.Features.UniversityPositions.Get;
using UniversityProcessing.DomainServices.Features.UniversityPositions.GetList;
using UniversityProcessing.GenericSubdomain.Attributes;

namespace UniversityProcessing.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class UniversityPositionController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [ValidateModel]
    public async Task<GetUniversityPositionResponseDto> Get([FromQuery] GetUniversityPositionRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUniversityPositionQueryRequest(request.Id);
        var response = await mediator.Send(query, cancellationToken);
        return new GetUniversityPositionResponseDto(UniversityPositionConverter.ToDto(response.UniversityPosition));
    }

    [HttpGet]
    public async Task<GetUniversityPositionsResponseDto> GetList([FromQuery] GetUniversityPositionsRequestDto request, CancellationToken cancellationToken)
    {
        var query = new GetUniversityPositionsQueryRequest(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var response = await mediator.Send(query, cancellationToken);
        return new GetUniversityPositionsResponseDto(UniversityPositionConverter.ToDto(response.List));
    }
}
